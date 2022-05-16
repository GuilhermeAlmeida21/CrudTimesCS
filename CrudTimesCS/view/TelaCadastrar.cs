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
    public partial class TelaCadastrar : Form
    {
        public TelaCadastrar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            times.NomeTimes= tbxNomeTime.Text;
            times.FraseTimes = tbxFrase.Text;
            times.LogoTimes = "c:/";

            manipulaTimes manipulaTimes = new manipulaTimes();
            manipulaTimes.cadastroTimes();

            if(times.Retorno == "Sim")
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
            foreach(Control ctl in this.Controls)
            {
                if( ctl is TextBox)
                {
                    ctl.Text = String.Empty;
                }
            }
        }

        private void TelaCadastrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27)
            {
                fecharCadastro();
            }
            
        }
    }
}
