using PokedexMVVM.Models;
using PokedexMVVM.Services;
using PokedexMVVM.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PokedexMVVM.ViewModels
{
    public class PokemonViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value); }
        }

        private int _weight;

        public int Weight
        {
            get { return _weight; }
            set { SetValue(ref _weight, value); }
        }

        private int _height;

        public int Height
        {
            get { return _height; }
            set { SetValue(ref _height, value); }
        }

        private Sprites _sprites;

        public Sprites Sprites
        {
            get { return _sprites; }
            set { SetValue(ref _sprites, value); }
        }

        private Command _closeCommand;
        public Command CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new Command(CloseMethod)); }
        }

        private void CloseMethod()
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        public PokemonViewModel(string url)
        {
            LoadItems(url);
        }

        private async void LoadItems(string url)
        {
            PokemonDetails pkn = await DependencyService.Get<PokemonService>().GetDetails(url);

            Name = pkn.Name;
            Weight = pkn.Weight;
            Height = pkn.Height;
            Sprites = pkn.Sprites;
        }
    }
}
