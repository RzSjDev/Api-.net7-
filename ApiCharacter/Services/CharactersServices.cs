using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using api.net.Data;
using api.net.Dto.getCharacter;
using api.net.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace api.net.Services
{
    public class CharactersServices : IcharactersServices
    {

        readonly private IMapper mapper;
        readonly private DataContext context;
        public CharactersServices(IMapper mapper, DataContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacters(AddCharacterDto newCharacters)
        {
            var services = new ServiceResponse<List<GetCharacterDto>>();
            var character = mapper.Map<Characters>(newCharacters);
            context.character.Add(character);
            await context.SaveChangesAsync();
            services.Data = await context.character.Select(c => mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return services;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacters(int id)
        {
            var services = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                var character = await context.character.FirstOrDefaultAsync(c => c.Id == id);
                if (character is null)
                {
                    throw new Exception($"character with id '{id}' not found");
                }
                context.character.Remove(character);
                services.Data = await context.character.Select(c => mapper.Map<GetCharacterDto>(c)).ToListAsync();
            }
            catch (Exception e)
            {
                services.Message = e.Message;
                services.succsess = false;
            }
            await context.SaveChangesAsync();

            return services;
        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> getAllCharacters()
        {
            var services = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacter = await context.character.ToListAsync();
            services.Data = dbCharacter.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();
            return services;
        }

        public async Task<ServiceResponse<GetCharacterDto>> getCharactersById(int id)
        {
            var services = new ServiceResponse<GetCharacterDto>();
            var dbcharacter = await context.character.SingleOrDefaultAsync(c => c.Id == id);
            services.Data = mapper.Map<GetCharacterDto>(dbcharacter);
            return services;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacters(UpdateCharacterDto UpdateCharacterDto)
        {
            var services = new ServiceResponse<GetCharacterDto>();
            var character = await context.character.FirstOrDefaultAsync(c => c.Id == UpdateCharacterDto.Id);
            character.name = UpdateCharacterDto.name;
            character.Hitpoint = UpdateCharacterDto.Hitpoint;
            character.Strength = UpdateCharacterDto.Strength;
            character.Defence = UpdateCharacterDto.Defence;
            character.Intelligence = UpdateCharacterDto.Intelligence;
            character.rpgclass = UpdateCharacterDto.rpgclass;
            await context.SaveChangesAsync();
            services.Data = mapper.Map<GetCharacterDto>(character);
            return services;
        }
    }
}
