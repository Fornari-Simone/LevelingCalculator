using AutoMapper;
using Character.Shared;
using LevelingCalculator.Repository.Model;
using Resource.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelingCalculator.Business.Profiles
{
    public sealed class AssemblyMarker
    {
        public AssemblyMarker() { }
    }

    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
    public class LevelingCalculatorProfiles : Profile
    {
        public LevelingCalculatorProfiles()
        {
            CreateMap<ResourceDTO, ResourceKafka>();
            CreateMap<ResourceKafka, ResourceDTO>();
            CreateMap<CharacterDTO, CharacterKafka>();
            CreateMap<CharacterKafka, CharacterDTO>();
        }
    }
}
