using SQLiteNetExtensions.Attributes;

namespace SwissPairings.Models
{
    public class Pairing : BaseModel<Pairing>
    {
        [ForeignKey(typeof(Tournament))]
        public int TournamentID { get; set; }
        public string White { get; set; }
        public string Black { get; set; }
    }
}
