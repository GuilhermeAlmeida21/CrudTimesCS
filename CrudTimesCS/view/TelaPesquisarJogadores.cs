using CrudTimesCS.controller;
using CrudTimesCS.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudTimesCS.view
{
    public partial class TelaPesquisarJogadores : Form
    {
        public TelaPesquisarJogadores()
        {
            InitializeComponent();
        }

        private void tbxPesquisarCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPesquisarJogador_Click(object sender, EventArgs e)
        {
            try
            {

                if (tbxPesquisarCodigo.Text == "")
                {
                    MessageBox.Show("Digite um codigo valido");
                    return;
                }
                else
                {
                    Jogadores.CodJogadores = Convert.ToInt32(tbxPesquisarCodigo.Text);
                }
                ManipulaJogadores manipula = new ManipulaJogadores();
                manipula.pesquisarCodigoJogadores();

                lblCodigo.Text = Jogadores.CodJogadores.ToString();
                tbxNome.Text = Jogadores.NomeJogadores;
                tbxEmail.Text = Jogadores.EmailJogadores;
                tbxFone.Text = Jogadores.FoneJogadores;
              
            }

            catch (Exception)
            {

            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (lblCodigo.Text == "")
            {
                MessageBox.Show("Digite um Codigo Válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                lblCodigo.Text = string.Empty;
                tbxNome.Text = string.Empty;
                tbxEmail.Text = string.Empty;
                tbxFone.Text = string.Empty;
             
                return;

            }

            var resposta = MessageBox.Show(" Deseja fazer as alterações no time " + lblCodigo.Text + "?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                Jogadores.CodJogadores = Convert.ToInt32(lblCodigo.Text);
                Jogadores.NomeJogadores = tbxNome.Text;
                Jogadores.EmailJogadores = tbxEmail.Text;
                Jogadores.FoneJogadores = tbxFone.Text;


                ManipulaJogadores manipulaJogadores = new ManipulaJogadores();
                manipulaJogadores.alterarJogadores();



            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Jogadores.CodJogadores = Convert.ToInt32(tbxPesquisarCodigo.Text);

            if (tbxPesquisarCodigo.Text == "")
            {
                MessageBox.Show("Digite um número válido");
                return;
            }


            var resposta = MessageBox.Show("Deseja excluir o Time" + tbxPesquisarCodigo.Text + "?",
             "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (resposta == DialogResult.Yes)
            {
                times.CodTimes = Convert.ToInt32(tbxPesquisarCodigo.Text);

                manipulaTimes manipulaTimes = new manipulaTimes();
                manipulaTimes.deletarTimes();
            }

            lblCodigo.Text = string.Empty;
            tbxNome.Text = string.Empty;
            tbxEmail.Text = string.Empty;
            tbxFone.Text = string.Empty;
        }
    }
}
