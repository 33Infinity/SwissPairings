using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Prism.Commands;
using SwissPairings.Models;
using SwissPairings.Utilities;
using Xamarin.Forms;
using static SwissPairings.Utilities.SqlHelper;

namespace SwissPairings.ViewModels
{
    public class PlayersViewModel : BaseViewModel
    {
        public PlayersViewModel() {
            Title = "Player";
            Players = new ObservableCollection<Player>();
            Player player = new Player();
            player.FirstName = "name1";
            Players.Add(player);
            player = new Player();
            player.FirstName = "name2";
            Players.Add(player);
        }

        public bool AddNewPlayerEnabled => !(string.IsNullOrEmpty(NewLastName) || string.IsNullOrEmpty(NewFirstName) || string.IsNullOrEmpty(NewUSCFID));

        private ObservableCollection<Player> thePlayers;
        public ObservableCollection<Player> Players
        {
            get => thePlayers;
            set
            {
                thePlayers = value;
                OnPropertyChanged(nameof(Players));
            }
        }
        private string theNewLastName;
        public string NewLastName {
            get => theNewLastName;
            set {
                theNewLastName = value;
                OnPropertyChanged(nameof(NewLastName));
                OnPropertyChanged(nameof(AddNewPlayerEnabled));
            }
        }
        private string theNewFirstName;
        public string NewFirstName
        {
            get => theNewFirstName;
            set
            {
                theNewFirstName = value;
                OnPropertyChanged(nameof(NewFirstName));
                OnPropertyChanged(nameof(AddNewPlayerEnabled));
            }
        }
        private string theNewUSCFID;
        public string NewUSCFID
        {
            get => theNewUSCFID;
            set
            {
                theNewUSCFID = value;
                OnPropertyChanged(nameof(NewUSCFID));
                OnPropertyChanged(nameof(AddNewPlayerEnabled));
            }
        }
        public ICommand AddNewPlayerCommand => new DelegateCommand<object>(HandleAddNewPlayer, CanAddNewPlayer);
        public ICommand DeletePlayerCommand => new DelegateCommand<object>(HandleDeletePlayer, CanDeletePlayer);

        private bool CanDeletePlayer(object arg) => true;

        private async void HandleDeletePlayer(object obj) {

            //bool answer = await Application.Current.MainPage.DisplayAlert("Delete Player?", "Are you sure you want to delete this player", "Yes", "No");
        }

        private void HandleAddNewPlayer(object obj) {
            Player playerModel = new Player {
                FirstName = NewFirstName,
                LastName = NewLastName,
                USCFID = NewUSCFID
            };
            Insert(playerModel);
            NewFirstName = string.Empty;
            NewLastName = string.Empty;
            NewUSCFID = string.Empty;
        }

        private bool CanAddNewPlayer(object context) => AddNewPlayerEnabled;
    }
}
