using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodoCoreList.DTO.Extensions
{
    public static class AutoMapperExtensions
    {
        private static IMapper _instance;
        public static void Init(IMapper mapper) => _instance = mapper;
        public static TDestinationType Map<TDestinationType>(this object obj) 
        {
            return _instance.Map<TDestinationType>(obj);
        }
        public static TDestinationType Map<TDestinationType>(this object obj, TDestinationType dest)
        {
            return _instance.Map(obj, dest);
        }
        public static IQueryable<TDestinationType> ProjectTo<TDestinationType>(this IQueryable query)
        {
            return _instance.ProjectTo<TDestinationType>(query);
        }
    }
}
