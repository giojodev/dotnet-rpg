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
        public async Task<ActionResult<List<Character>>> Get(){
            return Ok(await _characterService.GetAllCharacter());
        }
        [HttpGet("api/GetSingle/{Id}")]
        public async Task<ActionResult<Character>> GetSingle(int Id){
            return Ok(await _characterService.GetCharacterById(Id));
        }
        [HttpPost("api/addCharacter")]
        public async Task<ActionResult<Character>> AddCharacter(Character model){
            
            return Ok(await _characterService.AddCharacter(model));
        }
    }
}