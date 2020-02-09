using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Prism.Commands;
using SwissPairings.Models;
using SwissPairings.Utilities;
using static SwissPairings.Utilities.SqlHelper;

namespace SwissPairings.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {
        public PlayerViewModel() {
            Title = "Player";
            /*Players = new ObservableCollection<Player>();
            Player player = new Player();
            player.Name = "name1";
            Players.Add(player);
            player = new Player();
            player.Name = "name2";
            Players.Add(player);*/
        }

        public bool AddNewPlayerEnabled => !(string.IsNullOrEmpty(NewLastName) || string.IsNullOrEmpty(NewFirstName) || string.IsNullOrEmpty(NewUSCFID));

        public ObservableCollection<Player> Players { get; set; }
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

        private bool CanAddNewPlayer(object context) {
            return AddNewPlayerEnabled;
        }
    }
}
