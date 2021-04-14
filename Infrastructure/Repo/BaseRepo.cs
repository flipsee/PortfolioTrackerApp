using Common.Contracts;
using Common.Contracts.Models;
using Common.Contracts.Repo;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DapperExtensions;
using Common.Helper;
using Common.Sessions;
using System;

namespace Infrastructure.Repo
{
    public abstract class BaseSelectRepo<T> : IBaseSelectRepo<T> where T : class, IBaseModel
    {
        protected readonly ILogger logger;

        internal BaseSelectRepo(ILogger logger)
        {
            this.logger = logger;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(Utils.GetConnectionString("DefaultConnection"));
            }
        }

        public virtual ICollection<T> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                var result = conn.GetList<T>().ToList();
                conn.Close();
                return result;
            }
        }

        public virtual T GetById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                //var result = conn.Query<T>(SelectQuery + " WHERE Id = @Id", new { Id = id });
                //return result.FirstOrDefault();
                var result = conn.Get<T>(id);
                conn.Close();
                return result;
            }
        }
    }

    public abstract class BaseAddRepo<T> : BaseSelectRepo<T>, IBaseAddRepo<T> where T : class, IBaseModel
    {
        protected readonly SessionProvider session;
        internal BaseAddRepo(SessionProvider session, ILogger logger) : base(logger)
        {
            this.session = session;
        }

        public virtual T Add(T entity)
        {
            if (entity != null)
            {
                SetAddProperty(entity);
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    entity.Id = conn.Insert<T>(entity);
                    conn.Close();
                }
            }
            return entity;
        }

        public virtual ICollection<T> Add(ICollection<T> entities)
        {
            foreach (var item in entities)
                Add(item);
            return entities;
        }

        public virtual void Commit()
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int id)
        {
            Delete(GetById(id));
        }

        public virtual void Delete(T entity)
        {
            if (entity != null)
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    conn.Delete(entity);
                    conn.Close();
                }
            }
        }

        public virtual void Delete(ICollection<T> entities)
        {
            foreach (var item in entities)
                Delete(item);
        }

        protected virtual void SetAddProperty(T entity)
        {
            entity.AddDateTime_UTC = System.DateTime.UtcNow;
            if (this.session != null && this.session.session != null)
                entity.AddBy = this.session.session.UserName;
        }
    }

    public class BaseRepo<T> : BaseAddRepo<T>, IBaseRepo<T> where T : class, IBaseModel
    {
        internal BaseRepo(SessionProvider session, ILogger logger) : base(session, logger) { }

        public virtual T Disable(int id)
        {
            return Disable(GetById(id));
        }

        public virtual T Disable(T entity)
        {
            if (entity != null)
            {
                entity.Disabled = true;
                entity = Update(entity);
            }
            return entity;
        }

        public virtual ICollection<T> Disable(ICollection<T> entities)
        {
            foreach (var item in entities)
                Disable(item);
            return entities;
        }

        public virtual T Update(T entity)
        {
            if (entity != null)
            {
                SetUpdateProperty(entity);
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    conn.Update(entity);
                    conn.Close();
                }
            }
            return entity;
        }

        public virtual ICollection<T> Update(ICollection<T> entities)
        {
            foreach (var item in entities)
                Update(item);
            return entities;
        }

        protected virtual void SetUpdateProperty(T entity)
        {
            entity.ModDateTime_UTC = System.DateTime.UtcNow;
            if (this.session != null && this.session.session != null)
                entity.ModBy = this.session.session.UserName;
        }

        protected override void SetAddProperty(T entity)
        {
            base.SetAddProperty(entity);
            SetUpdateProperty(entity);
        }
    }

}
