using PokedexMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokedexMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokedexView : ContentPage
    {
        public PokedexView()
        {
            BindingContext = new PokedexViewModel();
            InitializeComponent();
        }
    }
}