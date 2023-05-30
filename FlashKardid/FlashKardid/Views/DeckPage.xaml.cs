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


        private async Task Flip(VisualElement from, VisualElement to)
        {
            await from.RotateYTo(-90, 300, Easing.SpringIn);
            to.RotationY = 90;
            to.IsVisible = true;
            from.IsVisible = false;
            await to.RotateYTo(0, 300, Easing.SpringOut);
        }

        private async void FlipToBack(object sender, EventArgs e)
        {
            var front = sender as Grid;
            var back = front.Parent.FindByName<Grid>("BackView");
            await Flip(front, back);
        }

        private async void FlipToFront(object sender, EventArgs e)
        {
            var back = sender as Grid;
            var front = back.Parent.FindByName<Grid>("FrontView");
            await Flip(back, front);
        }


    }
}