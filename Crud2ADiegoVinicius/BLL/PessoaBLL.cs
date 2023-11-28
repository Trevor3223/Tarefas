using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud2ADiegoVinicius.DAL;
using System.Data;

namespace Crud2ADiegoVinicius.BLL
{
    public class PessoaBLL
    {
        PessoaDAL pessoaDal = new PessoaDAL();
        //Metodo para listar
        public DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = pessoaDal.Listar();
                return dt;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

    }
}
