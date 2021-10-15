using PokedexMVVM.Models;
using PokedexMVVM.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokedexMVVM.Services
{
    public class PokemonService : ApiRequester
    {
        public async Task<PokemonRequest> GetAll(string url)
        {
            return await Get<PokemonRequest>(url);
        }

        public async Task<PokemonDetails> GetDetails(string url)
        {
            return await Get<PokemonDetails>(url);
        }
    }
}
