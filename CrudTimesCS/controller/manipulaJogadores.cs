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
    }
}
