using System;
using System.IO;
using SQLite;
using SwissPairings.Models;
using SwissPairings.Services;
using SwissPairings.Views;
using Xamarin.Forms;
using Player = SwissPairings.Models.Player;

namespace SwissPairings {
    public partial class App : Application {
        private static SQLiteConnection database;
        private static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SwissPairings.db3");

        public static SQLiteConnection Database {
            get {
                if (database == null) {
                    database = new SQLiteConnection(dbPath);
                    database.CreateTable<User>();
                    database.CreateTable<Pairing>();
                    database.CreateTable<TournamentPlayerList>();
                    database.CreateTable<Tournament>();
                    database.CreateTable<Round>();
                    database.CreateTable<Player>();
                }
                return database;
            }
        }

        public App() {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}