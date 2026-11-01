using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingForEon.Database
{
    public interface IDatabaseConnection
    {
        SqlConnection TSqlConnection { get; }
        static string ConnectionString { get; } = string.Empty;
    }
}
