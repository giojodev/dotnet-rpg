using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Models;

using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController: ControllerBase
    {
        
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("api/GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> Get(){
            return Ok(await _characterService.GetAllCharacter());
        }
        [HttpGet("api/GetSingle/{Id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> GetSingle(int Id){
            return Ok(await _characterService.GetCharacterById(Id));
        }
        [HttpPost("api/addCharacter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> AddCharacter(AddCharacterDTO model){
            
            return Ok(await _characterService.AddCharacter(model));
        }
        [HttpPut("api/UpdateCharacter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> UpdateCharacter(UpdateCharacterDTO model){
            var response=await _characterService.UpdateCharacter(model);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            else {
                return Ok(response);
            }
            
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> DeleteCharacter(int Id){
            var response=await _characterService.DeleteCharacter(Id);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            else {
                return Ok(response);
            }
        }
    }
}