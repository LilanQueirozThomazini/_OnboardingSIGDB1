using AutoMapper;
using System;
using System.Collections.Generic;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public static class InicializaAutoMapper
    {
        public static void Initialize()
        {
            //Static API Mapper
            Mapper.Initialize(m => m.AddProfiles(GetAutoMapperProfiles()));
        }

        private static IEnumerable<Type> GetAutoMapperProfiles()
        {
            return new List<Type> {
                typeof(ProfileCargo),
                typeof(ProfileFuncionario),
                typeof(ProfileEmpresa),
                typeof(ProfileFuncionarioCargo),
            };
        }
    }
}
