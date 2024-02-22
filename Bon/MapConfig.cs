using AutoMapper;
using BonAPI.Models;
using BonAPI.Models.DTOs;

namespace BonAPI
{
    public class MapConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Bon, BonDTO>();
                config.CreateMap<BonDTO, Bon>();
            });
            return mappingConfig;
        }
    }
}
