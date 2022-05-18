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
    }
}
