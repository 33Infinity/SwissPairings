using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissPairings.Utilities;
using SwissPairings.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwissPairings.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Player : ContentPage
    {
        public Player()
        {
            InitializeComponent();
        }

        private async void DeleteClicked(object sender, EventArgs e) {
            bool answer = await Application.Current.MainPage.DisplayAlert("Delete Player?", "Are you sure you want to delete this player", "Yes", "No");
            if (answer) {
                SqlHelper.Delete(((BindableObject)sender).BindingContext);
                var player = ((SwissPairings.ViewModels.BaseViewModel) ((Xamarin.Forms.Element) sender).Parent.Parent.Parent.Parent.Parent.Parent.BindingContext);
            }
        }
    }
}