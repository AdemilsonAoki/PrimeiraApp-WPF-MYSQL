using System.Data;
using MySql.Data.MySqlClient;

namespace PrimeiraAPP.Data
{
    class Conexao
    {

        MySqlConnection con = new MySqlConnection();

        private string conexao = "Server=localhost;Database=bancopim2semestre2020;Uid=root;Pwd=Brasileiro55@;";

        public Conexao()
        {
            con.ConnectionString = conexao;
        }
        public MySqlConnection AbrirBanco()
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }
        public void FecharBanco()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }



        }
    }
}
