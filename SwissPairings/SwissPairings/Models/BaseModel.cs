using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SwissPairings.Models
{
    public class BaseModel<T> where T : class {
        public BaseModel() { }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
