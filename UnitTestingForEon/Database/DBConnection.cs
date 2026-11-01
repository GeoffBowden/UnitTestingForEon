using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.SqlClient;    
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingForEon.Database
{
    public class DBConnection : IDatabaseConnection
    {
        public static string ServerName => "DESKTOP-9HTJ6DS";
        public static string DatabaseName => "AdventureWorks2025";
        public static string ConnectionString => $"Server={ServerName};Database={DatabaseName};Trusted_Connection=True;";
        public SqlConnection TSqlConnection 
        { 
            get 
            { 
                return new SqlConnection(DBConnection.ConnectionString); 
            } 
        }
    }
}
