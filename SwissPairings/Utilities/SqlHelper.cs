using System.Collections.Generic;
using static SwissPairings.App;

namespace SwissPairings.Utilities {
    public class SqlHelper {
        public static void Insert<T>(T model) {
            Database.Insert(model);
        }

        public static void Delete<T>(T model) {
            Database.Insert(model);
        }

        public static List<T> FindWhere<T>(T model, string[] columns, string[] values) where T : class, new() => Database.Query<T>("select * from user", "Password");
    }
}