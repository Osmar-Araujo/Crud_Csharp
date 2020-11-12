using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace Crud2.conexao
{
    class ConectaDB
    {
        private static string serverName = "localhost";
        private static string port = "5432";
        private static string userName = "postgres";
        private static string password = "mar1212";
        private static string dataBaseName = "cadastro";

        public static NpgsqlConnection getConexao()
        {
            try
            {
                string stgConexao = string.Format("Server = {0}; Port = {1}; user Id = {2}; Password = {3}; DataBase={4};",
                                                   serverName,
                                                   port,
                                                   userName,
                                                   password,
                                                   dataBaseName);

                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(stgConexao);


                npgsqlConnection.Open();


                return npgsqlConnection;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

