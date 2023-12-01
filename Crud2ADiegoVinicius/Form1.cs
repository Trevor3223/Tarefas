using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud2ADiegoVinicius.BLL;
using Crud2ADiegoVinicius.Model;
using System.Windows.Forms;

namespace Crud2ADiegoVinicius
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Metodo para limpar campos
        public void Limpar()
        {
            txtCódigo.Clear();
            txtNome.Clear();
            mtbCPF.Clear();
            mtbCelular.Clear();
            txtEndereco.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            mtbCEP.Clear();
            cbSexo.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;
            txtNome.BackColor = Color.White;
            mtbCPF.BackColor = Color.White;
            cbSexo.BackColor = Color.White;

        }
        //Metodo para editar
        public void Alterar(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            try
            {
                if (txtNome.Text.Trim() == String.Empty || txtNome.Text.Trim().Length < 3)
                {
                    MessageBox.Show("O Campo NOME Não pode ser vazio!", "Alerta!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information); //Exibe uma caixa de aleta
                    txtNome.BackColor = Color.LightYellow; //Mudar cor do campo
                    cbSexo.BackColor = Color.White;
                    mtbCPF.BackColor = Color.White;
                }

                else if (mtbCPF.MaskCompleted)
                {
                    MessageBox.Show("O Campo CPF Não pode ser vazio!", "Alerta!",
                   MessageBoxButtons.OK, MessageBoxIcon.Information); //Exibe uma caixa de aleta
                    txtNome.BackColor = Color.White; //Mudar cor do campo
                    cbSexo.BackColor = Color.White;
                    mtbCPF.BackColor = Color.LightYellow;
                }
                else if (cbSexo.Text == String.Empty)
                {
                    MessageBox.Show("O Campo Sexo Não pode ser vazio!", "Alerta!",
            MessageBoxButtons.OK, MessageBoxIcon.Information); //Exibe uma caixa de aleta
                    txtNome.BackColor = Color.White; //Mudar cor do campo
                    cbSexo.BackColor = Color.LightYellow;
                    mtbCPF.BackColor = Color.White;
                }
                else
                {
                    pessoa.Id = Convert.ToInt32(txtCódigo.Text);
                }
            }
            catch (Exception)
            {

            }
            {
                throw;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCódigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Salvar e Limpar
            Pessoa pessoa = new Pessoa();
            Salvar(pessoa);
            Limpar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Botão Alterar
            Pessoa pessoa = new Pessoa();
            Alterar(pessoa);
        }
    
    }

    private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Metodo para salvar
        private void Salvar(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            try
            {
                if (txtNome.Text.Trim() == String.Empty || txtNome.Text.Trim().Length < 3)
                {
                    MessageBox.Show("O Campo NOME Não pode ser vazio!", "Alerta!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information); //Exibe uma caixa de aleta
                    txtNome.BackColor = Color.LightYellow; //Mudar cor do campo
                    cbSexo.BackColor = Color.White;
                    mtbCPF.BackColor = Color.White;
                }
    
                else if (mtbCPF.MaskCompleted)
                {
                    MessageBox.Show("O Campo CPF Não pode ser vazio!", "Alerta!",
                   MessageBoxButtons.OK, MessageBoxIcon.Information); //Exibe uma caixa de aleta
                    txtNome.BackColor = Color.White; //Mudar cor do campo
                    cbSexo.BackColor = Color.White;
                    mtbCPF.BackColor = Color.LightYellow;
                }
                else if (cbSexo.Text == String.Empty)
                {
                    MessageBox.Show("O Campo Sexo Não pode ser vazio!", "Alerta!",
            MessageBoxButtons.OK, MessageBoxIcon.Information); //Exibe uma caixa de aleta
                    txtNome.BackColor = Color.White; //Mudar cor do campo
                    cbSexo.BackColor = Color.LightYellow;
                    mtbCPF.BackColor = Color.White;
                }
                else
                {
                    pessoa.Nome = txtNome.Text;
                    pessoa.Nascimento = dtNascimento.Text;
                    pessoa.Sexo = cbSexo.Text;
                    mtbCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //remove a mascara do campo cpf
                    pessoa.Cpf = mtbCPF.Text;
                    mtbCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    pessoa.Celular = mtbCelular.Text;
                    pessoa.Endereco = txtEndereco.Text;
                    pessoa.Bairro = txtBairro.Text;
                    pessoa.Cidade = txtCidade.Text;
                    pessoa.Estado = cbEstado.Text;
                    mtbCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    pessoa.Cep = mtbCEP.Text;

                    pessoaBLL.Salvar(pessoa);
                    MessageBox.Show("Cadastro realizado com sucesso!", "Aviso!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao realizar novo Cadastro!\n"+erro, "Erro!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //Metodo para listar os dados no grid
        private void Listar()
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            dataGridView.DataSource = pessoaBLL.Listar();
            try
            {
                dataGridView.DataSource = pessoaBLL.Listar();

                //Renomear Colunas
                dataGridView.Columns[0].HeaderText = "Codigo";
                dataGridView.Columns[1].HeaderText = "Nome";
                dataGridView.Columns[2].HeaderText = "Dt Nasc";
                dataGridView.Columns[3].HeaderText = "Sexo";
                dataGridView.Columns[4].HeaderText = "CPF";
                dataGridView.Columns[5].HeaderText = "Telefone";
                dataGridView.Columns[6].HeaderText = "Endereço";
                dataGridView.Columns[7].HeaderText = "Bairro";
                dataGridView.Columns[8].HeaderText = "Cidade";
                dataGridView.Columns[9].HeaderText = "UF";
                dataGridView.Columns[10].HeaderText = "CEP";

                //Excluir e mover colunas do datagrid

                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
                dataGridView.Columns[8].Visible = false;
                dataGridView.Columns[9].Visible = false;
                dataGridView.Columns[10].Visible = false;

                //Ajustar largura das colunas

                dataGridView.Columns[0].Width = 45;
                dataGridView.Columns[1].Width = 160;
                dataGridView.Columns[2].Width = 70;
                dataGridView.Columns[3].Width = 40;
                dataGridView.Columns[4].Width = 75;
                dataGridView.Columns[5].Width = 85;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao exibir os dados!\n" + erro, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExibir_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            txtCódigo.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            dtNascimento.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            cbSexo.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            mtbCPF.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            mtbCelular.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            txtEndereco.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
            txtBairro.Text = dataGridView.CurrentRow.Cells[7].Value.ToString();
            txtCidade.Text = dataGridView.CurrentRow.Cells[8].Value.ToString();
            cbEstado.Text = dataGridView.CurrentRow.Cells[9].Value.ToString();
            mtbCEP.Text = dataGridView.CurrentRow.Cells[10].Value.ToString();


        }
    }
}
