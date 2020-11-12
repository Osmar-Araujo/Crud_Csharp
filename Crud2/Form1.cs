using Crud2.utilitario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Crud2.conexao;

namespace Crud2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void BtnInsirir_Click(object sender, EventArgs e)
        {
           

            try
            {
                string prontuario = txtProntuario.Text;
                string nome = txtNome.Text;
                string documento = txtDocumento.Text;
                string endereco = txtEndereco.Text;
                string telefone = mtxtTelefone.Text;



                CadPaciente cdPaciente = new CadPaciente();
                cdPaciente.Prontuario = prontuario;
                cdPaciente.Nome = nome;
                cdPaciente.Documento = documento;
                cdPaciente.Endereco = endereco;
                cdPaciente.Telefone = telefone;


                cdPaciente.Cadastrar();

                Limpa_Campos();



                MessageBox.Show("Operação Realizada com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar. " + ex.Message, "Falha na operação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void BtnExibir_Click(object sender, EventArgs e)
        {
            CadPaciente paciente = new CadPaciente();

            dgvPacientes.DataSource = paciente.Listar();

        }

        private void BtnDeletar_Click(object sender, EventArgs e)
        {
            try
            {

                
                string prontuario = txtProntuario.Text;
                string nome = txtNome.Text;
                string documento = txtDocumento.Text;
                string endereco = txtEndereco.Text;
                string telefone = mtxtTelefone.Text;



                CadPaciente cdPaciente = new CadPaciente();
                cdPaciente.Prontuario = prontuario;
                cdPaciente.Nome = nome;
                cdPaciente.Documento = documento;
                cdPaciente.Endereco = endereco;
                cdPaciente.Telefone = telefone;

                cdPaciente.Deletar();

                Limpa_Campos();
                                             
                MessageBox.Show("Operação Realizada com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar. " + ex.Message, "Falha na operação",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                
                string prontuario = txtProntuario.Text;
                string nome = txtNome.Text;
                string documento = txtDocumento.Text;
                string endereco = txtEndereco.Text;
                string telefone = mtxtTelefone.Text;



                CadPaciente cdPaciente = new CadPaciente();
                cdPaciente.Prontuario = prontuario;
                cdPaciente.Nome = nome;
                cdPaciente.Documento = documento;
                cdPaciente.Endereco = endereco;
                cdPaciente.Telefone = telefone;
                

                cdPaciente.Atualizar ();

               
                Limpa_Campos();

                MessageBox.Show("Operação Realizada com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar. " + ex.Message, "Falha na operação",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Limpa_Campos()
        {           

            txtProntuario.Clear();
            txtNome.Clear();
            txtDocumento.Clear();
            mtxtTelefone.Clear();
            txtEndereco.Clear();

            txtProntuario.Focus();

        }
        private void DgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProntuario.Text  = Convert .ToString(dgvPacientes.Rows[e.RowIndex].Cells[0].Value);
            txtNome.Text = Convert.ToString(dgvPacientes.Rows[e.RowIndex].Cells[1].Value);
            txtDocumento.Text = Convert.ToString(dgvPacientes.Rows[e.RowIndex].Cells[2].Value);            
            txtEndereco.Text = Convert.ToString(dgvPacientes .Rows[e.RowIndex].Cells[3].Value);
            mtxtTelefone.Text = Convert.ToString(dgvPacientes.Rows[e.RowIndex].Cells[4].Value);
        }       
    }
}  
  



