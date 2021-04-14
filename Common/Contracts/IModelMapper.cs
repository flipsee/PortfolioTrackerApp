using Common.Contracts.Models;
using System.Collections.Generic;

namespace Common.Contracts
{
    /// <summary>
    /// use this class to abstract the dependency to AutoMapper
    /// </summary>
    /// <typeparam name="TCoreModel"></typeparam>
    /// <typeparam name="TModelVM"></typeparam>
    public interface IModelMapper<TCoreModel, TModelVM> : IModelMapper where TCoreModel : IBaseModel
    {
        TCoreModel Map(TModelVM modelVM);

        TModelVM Map(TCoreModel coreModel);

        void Map(TModelVM source, TCoreModel destination);

        ICollection<TModelVM> Map(ICollection<TCoreModel> coreModels);

        IList<TModelVM> Map(IList<TCoreModel> coreModels);

        List<TModelVM> Map(List<TCoreModel> coreModels);

        ICollection<TCoreModel> Map(ICollection<TModelVM> coreModels);

        IList<TCoreModel> Map(IList<TModelVM> coreModels);

        List<TCoreModel> Map(List<TModelVM> coreModels);

        IList<TCoreModel> MapToList(ICollection<TModelVM> coreModels);
        IList<TModelVM> MapToList(ICollection<TCoreModel> coreModels);

    }

    public interface IModelMapper
    {
        TDestination Map<TSource, TDestination>(TSource source)
          where TSource : class
          where TDestination : class;

        List<TDestination> Map<TSource, TDestination>(List<TSource> sourceList)
          where TSource : class
          where TDestination : class;

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
