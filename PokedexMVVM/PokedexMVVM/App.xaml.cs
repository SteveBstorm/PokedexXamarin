using PokedexMVVM.Services;
using PokedexMVVM.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokedexMVVM
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<PokemonService>();

            InitializeComponent();

            MainPage = new PokedexView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
