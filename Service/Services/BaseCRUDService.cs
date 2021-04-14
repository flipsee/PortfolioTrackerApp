using Common.Contracts.Models;
using Common.Contracts.Repo;
using Common.Contracts.Services;
using Common.Helper;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public enum OperationType
    {
        Add,
        Update,
        Disable,
        Remove
    }

    public class BaseCRUDService<T> : IBaseCRUDService<T> where T : IBaseModel
    {
        protected string logSource;
        protected readonly IBaseRepo<T> repo;

        public BaseCRUDService(IBaseRepo<T> repo)
        {
            this.repo = repo;
            this.logSource = $"BaseService<{typeof(T).Name}>";
        }

        public virtual bool Exists(int id)
        {
            return GetById(id) != null ? true : false;
        }

        public virtual T GetById(int id)
        {
            T _result = repo.GetById(id);
            return _result;
        }

        public virtual ICollection<T> GetAll()
        {
            ICollection<T> _result = repo.GetAll();
            return _result;
        }

        public virtual MessageObject<T> Add(T entity)
        {
            MessageObject<T> validationResult = ValidateAdd(entity);
            try
            {
                BasePreProcessing(ref entity, OperationType.Add);
                if (validationResult.ProcessingStatus)
                {
                    validationResult.Data = repo.Add(entity);
                    repo.Commit();

                    BasePostProcessing(ref entity, OperationType.Add);
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Log(ex, logSource);
                validationResult.AddException(ex);
            }
            return validationResult;
        }

        public virtual MessageObject<T> Update(T entity)
        {
            MessageObject<T> validationResult = ValidateUpdate(entity);
            try
            {
                BasePreProcessing(ref entity, OperationType.Update);
                if (validationResult.ProcessingStatus)
                {
                    repo.Update(entity);
                    //validationResult.Data = repo.GetById(entity.Id); //refresh
                    repo.Commit();

                    BasePostProcessing(ref entity, OperationType.Add);
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Log(ex, logSource);
                validationResult.AddException(ex);
            }
            return validationResult;
        }

        public virtual MessageObject<T> Disable(T entity)
        {
            MessageObject<T> validationResult = ValidateDisable(entity);
            try
            {
                BasePreProcessing(ref entity, OperationType.Disable);
                if (validationResult.ProcessingStatus)
                {
                    repo.Disable(entity);
                    repo.Commit();

                    BasePostProcessing(ref entity, OperationType.Add);
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Log(ex, logSource);
                validationResult.AddException(ex);
            }
            return validationResult;
        }

        public virtual MessageObject<T> Remove(T entity)
        {
            MessageObject<T> validationResult = ValidateRemove(entity);
            try
            {
                BasePreProcessing(ref entity, OperationType.Remove);
                if (validationResult.ProcessingStatus)
                {
                    repo.Delete(entity);
                    repo.Commit();

                    BasePostProcessing(ref entity, OperationType.Add);
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Log(ex, logSource);
                validationResult.AddException(ex);
            }
            return validationResult;
        }

        protected virtual void BasePreProcessing(ref T entity, OperationType operationType)
        { 
            //do nothing to be implmented by child class
        }

        protected virtual void BasePostProcessing(ref T entity, OperationType operationType)
        {
            //do nothing to be implmented by child class
        }

        #region Validation, override the validation if necessery, i.e. check duplicate or required fields.
        protected virtual MessageObject<T> ValidateAdd(T entity)
        {
            return new MessageObject<T>(entity);
        }

        protected virtual MessageObject<T> ValidateUpdate(T entity)
        {
            return new MessageObject<T>(entity);
        }

        protected virtual MessageObject<T> ValidateDisable(T entity)
        {
            return new MessageObject<T>(entity);
        }

        protected virtual MessageObject<T> ValidateRemove(T entity)
        {
            return new MessageObject<T>(entity);
        }

        #endregion 
    }
}
