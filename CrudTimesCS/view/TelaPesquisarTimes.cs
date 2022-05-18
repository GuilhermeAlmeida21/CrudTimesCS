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
    public partial class TelaPesquisarTimes : Form
    {
        public TelaPesquisarTimes()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {

                if (tbxCodigoTimes.Text == "")
                {
                    MessageBox.Show("Digite um codigo valido");
                    return;
                }
                else
                {
                    times.CodTimes = Convert.ToInt32(tbxCodigoTimes.Text);
                }
                manipulaTimes manipula = new manipulaTimes();
                manipula.pesquisarCodigoTimes();

                label4.Text = times.CodTimes.ToString();
                tbxFrase.Text = times.FraseTimes;
                tbxTime.Text = times.NomeTimes;
                MemoryStream ms = new MemoryStream((byte[])times.LogoTimes);
                pictureBox1.Image = Image.FromStream(ms);
            }

            catch (Exception)
            {

            }

        }
    }


}
