using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Datos
{
    public abstract class Conexion
    {
        private readonly string connectionString;
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        protected MySqlConnection GetConnection()
        {
            string connectionString;
            connectionString = "SERVER=QUE HACES ACA SAPO";

            return new MySqlConnection(connectionString);
        }

    }
}
