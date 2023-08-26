using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.DTO.Character
{
    public class UpdateCharacterDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }="Frodo";
        public int hitPoints { get; set; }=100;
        public int strength { get; set;}=10;
        public int defense { get; set; }=10;
        public int intelligence { get; set; } =10;
        public rpgClass Class { get; set; }=rpgClass.Knight;
    }
}