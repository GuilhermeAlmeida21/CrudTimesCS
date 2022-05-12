using System;
using System.Data;
using System.Data.SqlClient;
using CrudTimesCS.model;
using CrudTimesCS.view;
using System.Windows.Forms;


namespace CrudTimesCS.controller
{
    class manipulaTimes
    {
        public void cadastroTimes()
        {
            SqlConnection cn = new SqlConnection(conexaoBD.conectar());
            SqlCommand cmd = new SqlCommand("pInserirTimes", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@NomeTimes", times.NomeTimes);
                cmd.Parameters.AddWithValue("@LogoTimes", times.LogoTimes);
                cmd.Parameters.AddWithValue("@FraseTimes", times.FraseTimes);

                SqlParameter nv = cmd.Parameters.Add("@CodTimes", SqlDbType.Int);
                nv.Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();

                var resposta = MessageBox.Show("Cadastro efetuado com sucesso, deseja executar um novo cadastro? ", 
                    "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if(resposta == DialogResult.Yes)
                {
                    times.Retorno = "Sim";
                    return;

                }
                else
                {
                    times.Retorno = "Não";
                    return;
                }

            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
