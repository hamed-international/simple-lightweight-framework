using Shared.Utility._App;
using System.Data;
using System.Data.SqlClient;

namespace Domain.Model._App
{
    public class ConnectionKeeper
    {
        public static IDbConnection SqlConnection => new SqlConnection(AppSettings.SqlConnection);
    }
}
