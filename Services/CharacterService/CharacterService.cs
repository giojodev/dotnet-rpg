using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters= new List<Character>(){
            new Character(),
            new Character{Id=1,Name="Sam"}
        }; 
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public CharacterService(IMapper mapper,DataContext dataContext)
        {
            _mapper=mapper;
            _dataContext=dataContext;
        }
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            var serviceResponse=new ServiceResponse<List<GetCharacterDTO>>();
            var character = _mapper.Map<Character>(newCharacter);
            // character.Id = characters.Max(c=>c.Id) +1;

            // characters.Add(_mapper.Map<Character>(character));
            
            _dataContext.Characters.Add(character);
            await _dataContext.SaveChangesAsync();
            var ch= await _dataContext.Characters.ToListAsync();
            serviceResponse.Data = ch.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
        {
            var serviceResponse=new ServiceResponse<GetCharacterDTO>();
            var character= await _dataContext.Characters.Where(x=>x.Id==updatedCharacter.Id).FirstAsync();
            try 
            {
                if(character is null)
                    throw new Exception($"No fue encontrado un registro con el Id {updatedCharacter.Id}.");
                
                //Las siguientes opciones son viables si se desea utilizar el mapper para realizar actualizacion de los datos.
                // _mapper.Map<Character>(updatedCharacter);
                // _mapper.Map(updatedCharacter,character);

                character.Name=updatedCharacter.Name;
                character.strength=updatedCharacter.strength;
                character.defense=updatedCharacter.defense;
                character.intelligence=updatedCharacter.intelligence;
                character.Class=updatedCharacter.Class;
                character.hitPoints=updatedCharacter.hitPoints;
                
                _dataContext.Entry(character).State=EntityState.Modified;
                await _dataContext.SaveChangesAsync();

                serviceResponse.Data=_mapper.Map<GetCharacterDTO>(character);
                        
            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=$"{ex.Message}";
            }
            
           
            
            return serviceResponse; 

            
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacter()
        {
             var serviceResponse=new ServiceResponse<List<GetCharacterDTO>>();
            var dbCharacter= await _dataContext.Characters.ToListAsync();
            serviceResponse.Data=dbCharacter.Select(x => _mapper.Map<GetCharacterDTO>(x)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int Id)
        {
            var serviceResponse=new ServiceResponse<List<GetCharacterDTO>>();
            // var character= characters.First(x=>x.Id==Id);
            var dbCharacter=await _dataContext.Characters.Where(x=>x.Id==Id).FirstAsync();
            try 
            {
                if(dbCharacter is null)
                    throw new Exception($"No fue encontrado un registro con el Id {Id}.");
                
                //Las siguientes opciones son viables si se desea utilizar el mapper para realizar actualizacion de los datos.
                // _mapper.Map<Character>(updatedCharacter);
                // _mapper.Map(updatedCharacter,character);

                // characters.Remove(dbCharacter);
                _dataContext.Characters.Remove(dbCharacter);
                await _dataContext.SaveChangesAsync();
                var ch=await _dataContext.Characters.ToListAsync();
                serviceResponse.Data = ch.Select(x => _mapper.Map<GetCharacterDTO>(x)).ToList();
                        
            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=$"{ex.Message}";
            }
            
           
            
            return serviceResponse; 

            
        }
        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int Id)
        {
            var serviceResponse=new ServiceResponse<GetCharacterDTO>();
            // var character=characters.FirstOrDefault(x=>x.Id==Id);
            var dbCharacter=await _dataContext.Characters.Where(x=>x.Id==Id).FirstAsync();
            serviceResponse.Data=_mapper.Map<GetCharacterDTO>(dbCharacter);
            return serviceResponse;
        }
    }
}