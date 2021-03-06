using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudTimesCS.view
{
    public partial class TelaMenu : Form
    {
        public TelaMenu()
        {
            InitializeComponent();
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastrar telaCadastrar = new TelaCadastrar();
            telaCadastrar.ShowDialog();
        }

        private void cadastrarJogadoresMenu_Click(object sender, EventArgs e)
        {
            TelaCadastrarJogadores telaCadastrar = new TelaCadastrarJogadores();
            telaCadastrar.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaPesquisarTimes telaPesquisarTime = new TelaPesquisarTimes();
            telaPesquisarTime.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaPesquisarJogadores telaPesquisarJogadores = new TelaPesquisarJogadores();
            telaPesquisarJogadores.ShowDialog();
        }
    }
}
