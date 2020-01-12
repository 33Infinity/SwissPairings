using System.Collections.Generic;
using System.Threading.Tasks;
using SwissPairings.Models;

namespace SwissPairings.Utilities
{
    public class SqlHelper
    {
        public static void Insert<T>(T model) {
            App.Database.Insert(model);
        }

        public static List<T> FindWhere<T>(T model, string [] columns, string [] values) where T : class, new(){
            return App.Database.Query<T>("select * from user", "Password");
        }
    }
}
