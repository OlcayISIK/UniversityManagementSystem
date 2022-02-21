using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UMS.Core.Enums;
using UMS.Data.Entities;

namespace UMS.Business.Helpers
{
    public class CustomMapper
    {
        private readonly IMapper _mapper;

        public CustomMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        // TODO add an overload for language-less conversions
        /// <summary>
        /// Entity to DTO mapping
        /// </summary>
        public IQueryable<T> ProjectTo<T>(IQueryable query, Language language)
        {
            return _mapper.ProjectTo<T>(query, new { language });
        }

        public IQueryable<T> ProjectTo<T>(IQueryable query)
        {
            return _mapper.ProjectTo<T>(query);
        }

        /// <summary>
        /// Dto to Entity mapping
        /// </summary>
        public TEntity Map<TEntity>(object dto, Language language)
        {
            return _mapper.Map<TEntity>(dto, opts => opts.Items[nameof(Language)] = language);
        }
        public TEntity Map<TEntity>(object dto)
        {
            return _mapper.Map<TEntity>(dto);
        }

        /// <summary>
        /// In place mapping to be used in update operations. Updates only the given language properties.
        /// </summary>
        /// <param name="source">Source (DTO) object to be mapped</param>
        /// <param name="destination">Destination (Entity) object, which has other translations already filled.</param>
        /// <param name="language">The language currently being mapped.</param>
        public void Map<TSource, TDestination>(TSource source, TDestination destination, Language language)
        {
            _mapper.Map(source, destination, opts => opts.Items[nameof(Language)] = language);
        }
    }
}
