﻿using AutoMapper;
using AutoMapper.Mappers;
using System.Collections.Generic;

namespace AutoMapperAssist
{
    public static class ConfigurationHelpers
    {
        public static ConfigurationStore CreateDefaultConfiguration()
        {
			return new ConfigurationStore (new TypeMapFactory(), new List<IObjectMapper>());
            //return new ConfigurationStore(new TypeMapFactory(), MapperRegistry.AllMappers);
        }
    }
}