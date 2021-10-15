using System;
using System.Collections.Generic;
using System.Text;

namespace PokedexMVVM.Models
{
    public class PokemonRequest
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public IEnumerable<Result> Results { get; set; }
    }
}
