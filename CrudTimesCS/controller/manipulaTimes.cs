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

        public void pesquisarCodigoTimes()
        {
            SqlConnection cn = new SqlConnection(conexaoBD.conectar());
            SqlCommand cmd = new SqlCommand("pBuscaCodigoTimes", cn);
            cmd.CommandType = CommandType.StoredProcedure;



            try
            {
                cmd.Parameters.AddWithValue("@CodTimes", times.CodTimes);
                cn.Open();
                var arrayDados = cmd.ExecuteReader();



                if (arrayDados.Read())
                {
                    times.CodTimes = Convert.ToInt32(arrayDados["CodTimes"]);
                    times.NomeTimes = arrayDados["NomeTimes"].ToString();
                    times.FraseTimes = arrayDados["FraseTimes"].ToString();
                    times.LogoTimes = (System.Array)arrayDados["LogoTimes"];
                    times.Retorno = "Sim";
                }
                else
                {
                    MessageBox.Show("Codigo não localizado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    times.Retorno = "Não";
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
