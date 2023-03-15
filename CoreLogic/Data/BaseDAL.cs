using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using System.Data.SqlClient;

namespace CoreLogic.Data;
abstract class BaseDAL
{
    private readonly string _connectionString;
    public BaseDAL()
    {
        var server = "(localdb)";
        var instance = "mssqllocaldb";
        var database = "StudentDB";
        var authentication = "Integrated Security = true";

        _connectionString = $"Data Source={server}\\{instance}; Initial Catalog={database};{authentication}";
    }

    public int ExecuteNonQuery(string qry)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            using (var command = new SqlCommand(qry, connection))
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }
    }
    public DataTable ExecuteQuery(string qry)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            using (var command = new SqlCommand(qry, connection))
            {
                using (var adapter = new SqlDataAdapter(command))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }
    }
}
