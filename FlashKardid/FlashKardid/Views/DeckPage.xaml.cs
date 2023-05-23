using FlashKardid.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace FlashKardid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeckPage : ContentPage
    {



        public DeckPage()
        {
            InitializeComponent();
        }

        private void SaveDeck(object sender, EventArgs e)
        {



        }
        private void DeleteDeck(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }


    }
}