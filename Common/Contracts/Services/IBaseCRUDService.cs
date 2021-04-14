using Common.Contracts.Models;
using Common.Helper;
using System.Collections.Generic;

namespace Common.Contracts.Services
{
    public interface IBaseCRUDService<T> where T : IBaseModel
    {
        bool Exists(int id);

        T GetById(int id);

        ICollection<T> GetAll();

        MessageObject<T> Add(T entity);

        MessageObject<T> Update(T entity);

        MessageObject<T> Disable(T entity);

        MessageObject<T> Remove(T entity);         
    }
}
