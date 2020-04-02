using AutoMapper;
using TodoCoreList.DTO.Mapper.Profiles;

namespace TodoCoreList.DTO.Mapper
{
    public static class MappingConfiguration
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TodoProfile>();
            });

            return config;
        }
    }
}
