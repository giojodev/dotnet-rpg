using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        List<Character> GetAllCharacter();
        Character GetCharacterById(int Id);
        List<Character> AddCharacter(Character newCharacter);
    }
}