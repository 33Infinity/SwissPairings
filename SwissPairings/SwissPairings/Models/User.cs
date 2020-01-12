using SQLite;


namespace SwissPairings.Models
{
    public class User : BaseModel<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
