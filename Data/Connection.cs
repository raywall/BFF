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
            var args = Environment.GetEnvironmentVariables();

            if (sqlConn == null)
                sqlConn = new MySqlConnection($"Server={args["DBURL"]};Database=teste;Uid={args["DBUSR"]};Pwd={args["DBPWD"]};");
        }
    }
}

