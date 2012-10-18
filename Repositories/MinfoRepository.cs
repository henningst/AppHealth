using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppHealth;

namespace Repositories
{
    public class MinfoRepository : IHealthCheckable
    {
        public bool IsUp()
        {
            using (var connection = new OracleConnection("Data Source=xx;user id=xx;password=xx"))
            {
                connection.Open();
                using (var cmd = new OracleCommand(@"SELECT count(*) FROM Groups", connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }
    }
}
