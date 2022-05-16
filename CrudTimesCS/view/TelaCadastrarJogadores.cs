using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudTimesCS.model;
using CrudTimesCS.controller;

namespace CrudTimesCS.view
{
    public partial class TelaCadastrarJogadores : Form
    {
        public TelaCadastrarJogadores()
        {
            InitializeComponent();
        }

        private void btnCancelarJogadores_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrarJogadores_Click(object sender, EventArgs e)
        {
            Jogadores.NomeJogadores = tbxNomeJogadores.Text;
            Jogadores.EmailJogadores = tbxEmailJogadores.Text;
            Jogadores.FoneJogadores = tbxFoneJogadores.Text;

            ManipulaJogadores ManipulaJogadores = new ManipulaJogadores();
            ManipulaJogadores.CadastroJogadores();

            if (Jogadores.Retorno == "Sim")
            {
                limparTela();
                return;
            }
            else
            {
                fecharCadastro();
                return;
            }

        }

        public void abrirCadastro()
        {
            this.ShowDialog();
        }
        public void fecharCadastro()
        {
            this.Close();
        }
        public void limparTela()
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox)
                {
                    ctl.Text = String.Empty;
                }
            }
        }

        private void TelaCadastrarJogadores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                fecharCadastro();
            }
        }
    }
}
