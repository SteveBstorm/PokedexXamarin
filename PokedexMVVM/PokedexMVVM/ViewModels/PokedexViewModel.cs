using PokedexMVVM.Models;
using PokedexMVVM.MVVMTools;
using PokedexMVVM.Services;
using PokedexMVVM.Tools;
using PokedexMVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace PokedexMVVM.ViewModels
{
    public class PokedexViewModel : ViewModelBase
    {
        public ObservableCollection<Result> PokeList { get; set; }

        private Result _selectedPokemon;

        public Result SelectedPokemon
        {
            get { return _selectedPokemon; }
            set 
            {
                SetValue(ref _selectedPokemon, value);
                if(!(_selectedPokemon is null))
                App.Current.MainPage.Navigation.PushModalAsync(new PokemonView(_selectedPokemon.Url));    
            }
        }
        private string _next;

        public string Next
        {
            get { return _next; }
            set {
                SetValue(ref _next, value);
                //Button next = (Button)App.Current.MainPage.Navigation.NavigationStack[0].FindByName("next");
                //if (value != null)
                //    next.IsEnabled = true;
                //else next.IsEnabled = false;
                _nextCommand.ChangeCanExecute();
            }
        }


        private string _previous;
        public string Previous 
        { 
            get { return _previous; }
            set { 
                SetValue(ref _previous, value);
                //Button prev = (Button)App.Current.MainPage.Navigation.NavigationStack[0].FindByName("prev");
                //if (value != null)
                //    prev.IsEnabled = true;
                //else prev.IsEnabled = false;
                _previousCommand.ChangeCanExecute();

            }
        }


        private Command _nextCommand;

        public Command NextCommand
        {
            get { return _nextCommand ?? (_nextCommand = new Command(NextMethod, CanNext)); }
        }        

        private void NextMethod() 
        {
            LoadItems(_next);
        }

        private bool CanNext()
        {
            if (_next == null) return false;
            return true;
        }

        private Command _previousCommand;

        public Command PreviousCommand
        {
            get { return _previousCommand ?? (_previousCommand = new Command(PreviousMethod, CanPrevious)); }
            set { SetValue(ref _previousCommand, value);  }
        }

        public bool CanPrevious()
        {
            if (_previous == null) return false;
            return true;
        }

        private void PreviousMethod()
        {
            LoadItems(_previous);
        }


        public PokedexViewModel()
        {
            
            PokeList = new ObservableCollection<Result>();
            LoadItems("https://pokeapi.co/api/v2/pokemon");
        }

        private async void LoadItems(string url)
        {
            PokeList.Clear();

            PokemonRequest req = await DependencyService.Get<PokemonService>().GetAll(url);
            
            foreach (Result item in req.Results)
            {
                PokeList.Add(item);
            }

            Next = req.Next;
            Previous = req.Previous;
        }

    }
}
