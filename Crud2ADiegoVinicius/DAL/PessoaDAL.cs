using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Crud2ADiegoVinicius.Model;
using System.Data;

namespace Crud2ADiegoVinicius.DAL
{
    public class PessoaDAL : Conexao
    {
        MySqlCommand comando = null;

        //Metodo para Listar

        public DataTable Listar()
        {
            try
            {
                AbrirConexao();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                comando = new MySqlCommand("SELECT * FROM pessoa ORDER BY nome", conexao);
                da.SelectCommand = comando;
                da.Fill(dt);
                return dt;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
    }
}
