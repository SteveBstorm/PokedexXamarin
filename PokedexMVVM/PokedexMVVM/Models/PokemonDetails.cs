using System;
using System.Collections.Generic;
using System.Text;

namespace PokedexMVVM.Models
{
    public class PokemonDetails
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public Sprites Sprites { get; set; }
    }
}
