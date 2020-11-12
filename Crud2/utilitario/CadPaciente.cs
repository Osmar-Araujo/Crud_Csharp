using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Crud2.conexao;
using System.Data;
using System.Windows.Forms;

namespace Crud2.utilitario
{
    class CadPaciente
    {
        public string Prontuario { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public CadPaciente()
        {

        }

        public CadPaciente(string prontuario, string nome, string documento, string endereco,
            string telefone)
        {
            this.Prontuario = prontuario;
            this.Nome = nome;
            this.Documento = documento;
            this.Endereco = endereco;
            this.Telefone = telefone;

        }
        public void Cadastrar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "INSERT INTO paciente (prontuario,nome,documento,endereco,telefone) values " +
                    "('" + this.Prontuario + "','" + this.Nome + "','" + this.Documento + "','" + this.Endereco + "','" + this.Telefone + "')";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }

            }
        }

        public List<CadPaciente> Listar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "SELECT * from paciente Order by nome";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                List<CadPaciente> listapaciente = new List<CadPaciente>();
                while (dr.Read())
                {
                    CadPaciente paciente = new CadPaciente();
                    paciente.Prontuario = dr["prontuario"].ToString();
                    paciente.Nome = dr["nome"].ToString();
                    paciente.Documento = dr["documento"].ToString();
                    paciente.Endereco = dr["endereco"].ToString();
                    paciente.Telefone = dr["telefone"].ToString();

                    listapaciente.Add(paciente);

                }
                return listapaciente;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }

            }
        }

        public void Deletar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
              
                string sql = "DELETE FROM paciente WHERE prontuario = '" + this.Prontuario + "'";
            
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }

            }


        }

        public void  Atualizar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();

                string sql = "UPDATE paciente SET nome = '" + this.Nome + "',documento = '"+this.Documento+"',endereco = '"+this.Endereco+"',telefone = '" +this.Telefone+ "' WHERE prontuario = '"+this.Prontuario+"'";
                   
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }

            }           

        }   

            
    }
   
} 



    

   