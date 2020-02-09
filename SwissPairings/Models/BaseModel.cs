using System;
using SQLite;

namespace SwissPairings.Models
{
    public class BaseModel<T> where T : class {
        public BaseModel() { }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }
}
