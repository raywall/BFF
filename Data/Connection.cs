using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace BFF.Data
{
    public abstract class Connection : ControllerBase
    {
        public MySqlConnection sqlConn;

        public Connection()
        {
            if (sqlConn == null)
                sqlConn = new MySqlConnection("Server=localhost;Database=teste;Uid=tester;Pwd=tester123;");
        }
    }
}

