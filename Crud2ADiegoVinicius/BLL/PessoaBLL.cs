using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud2ADiegoVinicius.DAL;
using System.Data;
using Crud2ADiegoVinicius.Model;

namespace Crud2ADiegoVinicius.BLL
{
    public class PessoaBLL 
    {
        PessoaDAL pessoaDal = new PessoaDAL();
        //Metodo para editar
        public void Alterar()
        {
            try
            {
                pessoaDAL.Alterar(pessoa);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
        //Metodo para salvar

        public void Salvar(Pessoa pessoa)
        {
            try
            {
                pessoaDal.Salvar(pessoa);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
        
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
