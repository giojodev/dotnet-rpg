using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<Character>>> GetAllCharacter();
        Task<ServiceResponse<Character>> GetCharacterById(int Id);
        Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter);
    }
}