using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Projeto.DAL.Repositorio
{
    public class Conexao
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;

        protected void AbirConexao()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Banco"].ConnectionString);
            con.Open();
        }


        protected void FecharConexao()
        {
            con.Close();
        }
    }
}
