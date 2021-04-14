using AutoMapper;
using Common.Contracts;
using Common.Contracts.Models;
using System.Collections.Generic;

namespace Common.Helper
{
    public class ModelMapper<TCoreModel, TModelVM> : ModelMapper, IModelMapper<TCoreModel, TModelVM> where TCoreModel : IBaseModel where TModelVM : class
    {
        public ModelMapper(IMapper mapper) : base(mapper) { }

        public TCoreModel Map(TModelVM modelVM)
        {
            return mapper.Map<TCoreModel>(modelVM);
        }

        public TModelVM Map(TCoreModel coreModel)
        {
            return mapper.Map<TModelVM>(coreModel);
        }

        public void Map(TModelVM source, TCoreModel destination)
        {
            mapper.Map<TModelVM, TCoreModel>(source, destination);
        }


        public ICollection<TModelVM> Map(ICollection<TCoreModel> coreModels)
        {
            return mapper.Map<ICollection<TCoreModel>, ICollection<TModelVM>>(coreModels);
        }

        public ICollection<TCoreModel> Map(ICollection<TModelVM> coreModels)
        {
            return mapper.Map<ICollection<TModelVM>, ICollection<TCoreModel>>(coreModels);
        }

        public IList<TModelVM> Map(IList<TCoreModel> coreModels)
        {
            return mapper.Map<IList<TCoreModel>, IList<TModelVM>>(coreModels);
        }

        public IList<TCoreModel> Map(IList<TModelVM> coreModels)
        {
            return mapper.Map<IList<TModelVM>, IList<TCoreModel>>(coreModels);
        }

        public List<TModelVM> Map(List<TCoreModel> coreModels)
        {
            return mapper.Map<List<TCoreModel>, List<TModelVM>>(coreModels);
        }

        public List<TCoreModel> Map(List<TModelVM> coreModels)
        {
            return mapper.Map<List<TModelVM>, List<TCoreModel>>(coreModels);
        }

        public IList<TCoreModel> MapToList(ICollection<TModelVM> coreModels)
        {
            return mapper.Map<ICollection<TModelVM>, IList<TCoreModel>>(coreModels);
        }

        public IList<TModelVM> MapToList(ICollection<TCoreModel> coreModels)
        {
            return mapper.Map<ICollection<TCoreModel>, IList<TModelVM>>(coreModels);
        }
    }

    public class ModelMapper : IModelMapper
    {
        public readonly IMapper mapper;

        public ModelMapper(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
          where TSource : class
          where TDestination : class
        {
            return mapper.Map<TDestination>(source);
        }

        public List<TDestination> Map<TSource, TDestination>(List<TSource> sourceList)
          where TSource : class
          where TDestination : class
        {
            return mapper.Map<List<TSource>, List<TDestination>>(sourceList);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return mapper.Map<TSource, TDestination>(source, destination);
        }
    }
}
