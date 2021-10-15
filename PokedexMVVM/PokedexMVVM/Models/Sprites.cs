using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokedexMVVM.Models
{
    public class Sprites
    {
        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }
        [JsonProperty("back_default")]
        public string BackDefault { get; set; }
    }
}
