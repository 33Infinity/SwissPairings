using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using SQLiteNetExtensions.Attributes;

namespace SwissPairings.Models
{
    public class Round : BaseModel<Round>
    {
        [ForeignKey(typeof(Tournament))]
        public int TournamentID { get; set; }
        public int Number { get; set; }

    }
}
