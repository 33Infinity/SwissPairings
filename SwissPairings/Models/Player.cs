using System;
using System.Collections.Generic;
using System.Text;

namespace SwissPairings.Models
{
    public class Player : BaseModel<Player>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RegularRating { get; set; } = 1200;
        public int QuickRating { get; set; } = 1200;
        public int BlitzRating { get; set; } = 1200;
        public string USCFID { get; set; }
    }
}
