using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters= new List<Character>(){
            new Character(),
            new Character{Id=1,Name="Sam"}
        }; 
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            var serviceResponse=new ServiceResponse<List<AddCharacterDTO>>();
            characters.Add(newCharacter);
            serviceResponse.Data=characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacter()
        {
            var serviceResponse=new ServiceResponse<List<GetCharacterDTO>>();
            serviceResponse.Data=characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int Id)
        {
            var serviceResponse=new ServiceResponse<GetCharacterDTO>();
            var character=characters.FirstOrDefault(x=>x.Id==Id);
            serviceResponse.Data=character;
            return serviceResponse;
        }
    }
}