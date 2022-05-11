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
    }
}
