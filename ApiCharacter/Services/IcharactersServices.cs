using api.net.Dto.getCharacter;
using api.net.Models;

namespace api.net.Services
{
    public interface IcharactersServices
    {
        public Task<ServiceResponse<List<GetCharacterDto>>> getAllCharacters();
        public Task<ServiceResponse<GetCharacterDto>> getCharactersById(int id);
        public Task<ServiceResponse<List<GetCharacterDto>>> AddCharacters(AddCharacterDto addCharacterDto);
        public Task<ServiceResponse<GetCharacterDto>> UpdateCharacters(UpdateCharacterDto addCharacterDto);
        public Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacters(int id);
    }
}