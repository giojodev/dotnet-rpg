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
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper=mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            var serviceResponse=new ServiceResponse<List<GetCharacterDTO>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c=>c.Id) +1;

            characters.Add(_mapper.Map<Character>(character));
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacter()
        {
            var serviceResponse=new ServiceResponse<List<GetCharacterDTO>>();
            serviceResponse.Data=characters.Select(x => _mapper.Map<GetCharacterDTO>(x)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int Id)
        {
            var serviceResponse=new ServiceResponse<GetCharacterDTO>();
            var character=characters.FirstOrDefault(x=>x.Id==Id);
            serviceResponse.Data=_mapper.Map<GetCharacterDTO>(character);
            return serviceResponse;
        }
    }
}