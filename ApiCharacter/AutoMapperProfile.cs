using api.net.Dto.getCharacter;
using api.net.Models;
using AutoMapper;

namespace api.net
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetCharacterDto, Characters>();
            CreateMap<AddCharacterDto, Characters>();
        }
    }
}