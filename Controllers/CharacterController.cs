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
        private static List<Character> characters= new List<Character>(){
            new Character(),
            new Character{Id=1,Name="Sam"}
        }; 

        [HttpGet("api/GetAll")]
        public ActionResult<List<Character>> Get(){
            return Ok(characters);
        }
        [HttpGet("api/GetSingle/{Id}")]
        public ActionResult<Character> GetSingle(int Id){
            return Ok(characters.FirstOrDefault(x=>x.Id==Id));
        }
        [HttpPost("api/addCharacter")]
        public ActionResult<Character> AddCharacter(Character model){
            characters.Add(model);
            return Ok(characters);
        }
    }
}