using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SQLiteNetExtensions.Attributes;

namespace SwissPairings.Models
{
    public class TournamentPlayerList : BaseModel<TournamentPlayerList>
    {
        [ForeignKey(typeof(Tournament))]
        public int TournamentID { get; set; }
        public int PlayerID { get; set; }
    }
}
