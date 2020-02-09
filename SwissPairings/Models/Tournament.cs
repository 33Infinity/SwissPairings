using System;
using System.Collections.Generic;
using System.Text;
using SQLiteNetExtensions.Attributes;

namespace SwissPairings.Models
{
    public class Tournament : BaseModel<Tournament>
    {
        public string Name { get; set; }
        public string TimeControl { get; set; }
        public int Rounds { get; set; }
        public string Status { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]   
        public List<TournamentPlayerList> TournamentPlayerList { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Pairing> Pairing { get; set; }
    }
}
