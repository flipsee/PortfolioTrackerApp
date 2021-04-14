using Common.Contracts.Models;
using System.Collections.Generic;

namespace Common.Contracts.Repo
{
    public interface IBaseSelectRepo<T> where T : IBaseModel
    {
        ICollection<T> GetAll();
        T GetById(int id); 
    }

    public interface IBaseAddRepo<T> : IBaseSelectRepo<T> where T : IBaseModel
    {
        T Add(T entity);
        ICollection<T> Add(ICollection<T> entities);

        void Delete(int id);
        void Delete(T entity);
        void Delete(ICollection<T> entities);

        void Commit();
    }

    public interface IBaseRepo<T> : IBaseAddRepo<T> where T : IBaseModel
    {
        T Update(T entity);
        ICollection<T> Update(ICollection<T> entities);

        T Disable(int id);
        T Disable(T entity);
        ICollection<T> Disable(ICollection<T> entities);
    }
}
