using Common.Contracts;
using Common.Contracts.Models;
using Common.Contracts.Repo;
using Common.Sessions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Infrastructure.Repo
{
    public abstract class BaseXMLSelectRepo<T> : IBaseSelectRepo<T> where T : class, IBaseModel
    {
        protected readonly ILogger logger;        
        protected readonly string fileName;

        private List<T> _dataSet = null;

        internal BaseXMLSelectRepo(ILogger logger)
        {
            this.logger = logger;
            T instance = Activator.CreateInstance<T>();
            this.fileName = instance.GetType().Name + ".xml";
        }

        public int getNextId()
        {
            if (GetAll().Count > 0)
                return GetAll().Last().Id + 1;
            else
                return 1;
        }

        public List<T> readXMLtoList()
        {
            List<T> result = new List<T>();
            try
            {
                if (File.Exists(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                    using (FileStream stream = File.OpenRead(fileName))
                    {
                        result = (List<T>)serializer.Deserialize(stream);
                    }
                }
            }
            catch
            {
             //do nothing;   
            }
            return result;
        }

        public virtual ICollection<T> GetAll()
        {
            if (this._dataSet == null)
                _dataSet = readXMLtoList();
            return _dataSet;
        }

        public virtual T GetById(int id)
        {
            return GetAll().Where(p => p.Id == id).FirstOrDefault();            
        }        
    }

    public abstract class BaseXMLAddRepo<T> : BaseXMLSelectRepo<T>, IBaseAddRepo<T> where T : class, IBaseModel
    {        
        protected readonly SessionProvider session;
        internal BaseXMLAddRepo(SessionProvider session, ILogger logger) : base(logger)
        {
            this.session = session;
        }

        public void writeListtoXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (FileStream stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, GetAll().OrderBy(p => p.Id).ToList());
            }
        }

        public virtual void Commit()
        {
            writeListtoXML();
        }

        public virtual T Add(T entity)
        {
            if (entity != null)
            {
                SetAddProperty(entity);
                entity.Id = getNextId();
                GetAll().Add(entity);
            }
            return entity;
        }

        public virtual ICollection<T> Add(ICollection<T> entities)
        {
            foreach (var item in entities)
                Add(item);

            Commit();
            return entities;
        }

        public virtual void Delete(int id)
        {
            Delete(GetById(id));
        }

        public virtual void Delete(T entity)
        {
            if (entity != null)
            {
                GetAll().Remove(entity);
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

    public class BaseXMLRepo<T> : BaseXMLAddRepo<T>, IBaseRepo<T> where T : class, IBaseModel
    {
        public BaseXMLRepo(SessionProvider session, ILogger logger) : base(session, logger) { }

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
                var item = GetAll().FirstOrDefault(p => p.Id == entity.Id);
                item = entity;                
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
