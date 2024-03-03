using api.net.Dto.getCharacter;
using api.net.Models;
using api.net.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly IcharactersServices icharactersServices;
        public CharacterController(IcharactersServices icharactersServices)
        {
            this.icharactersServices = icharactersServices;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok(await icharactersServices.getAllCharacters());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {
            return Ok(await icharactersServices.getCharactersById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Addcharacters(AddCharacterDto newcharacters)
        {

            return Ok(await icharactersServices.AddCharacters(newcharacters));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Updatecharacters(UpdateCharacterDto updatecharacters)
        {

            return Ok(await icharactersServices.UpdateCharacters(updatecharacters));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Deletecharacters(int id)
        {

            return Ok(await icharactersServices.DeleteCharacters(id));
        }

    }

}