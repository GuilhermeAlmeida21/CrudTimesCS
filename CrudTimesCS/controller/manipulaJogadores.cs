using System;
using System.Data;
using System.Data.SqlClient;
using CrudTimesCS.model;
using CrudTimesCS.view;
using System.Windows.Forms;

namespace CrudTimesCS.controller
{
    class ManipulaJogadores
    {
        public void CadastroJogadores()
        {
            SqlConnection cn = new SqlConnection(conexaoBD.conectar());
            SqlCommand cmd = new SqlCommand("pInserirJogadores", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@NomeJogadores", Jogadores.NomeJogadores);
                cmd.Parameters.AddWithValue("@EmailJogadores", Jogadores.EmailJogadores);
                cmd.Parameters.AddWithValue("@FoneJogadores", Jogadores.FoneJogadores);

                SqlParameter nv = cmd.Parameters.Add("@CodJogadores", SqlDbType.Int);
                nv.Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();

                var resposta = MessageBox.Show("Cadastro efetuado com sucesso, deseja executar um novo cadastro? ",
                    "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (resposta == DialogResult.Yes)
                {
                    Jogadores.Retorno = "Sim";
                    return;

                }
                else
                {
                    Jogadores.Retorno = "Não";
                    return;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void pesquisarCodigoJogadores()
        {
            SqlConnection cn = new SqlConnection(conexaoBD.conectar());
            SqlCommand cmd = new SqlCommand("pBuscarCodigoJogadores", cn);
            cmd.CommandType = CommandType.StoredProcedure;



            try
            {
                cmd.Parameters.AddWithValue("@CodJogadores", Jogadores.CodJogadores);
                cn.Open();
                var arrayDados = cmd.ExecuteReader();



                if (arrayDados.Read())
                {
                    Jogadores.CodJogadores = Convert.ToInt32(arrayDados["CodJogadores"]);
                    Jogadores.NomeJogadores= arrayDados["NomeJogadores"].ToString();
                    Jogadores.EmailJogadores= arrayDados["EmailJogadores"].ToString();
                    Jogadores.FoneJogadores= arrayDados["FoneJogadores"].ToString();
                    Jogadores.Retorno = "Sim";
                }
                else
                {
                    MessageBox.Show("Codigo não localizado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Jogadores.Retorno = "Não";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
