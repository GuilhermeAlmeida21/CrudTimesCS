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

                lblCodigoTime.Text = times.CodTimes.ToString();
                tbxFrase.Text = times.FraseTimes;
                tbxTime.Text = times.NomeTimes;
                MemoryStream ms = new MemoryStream((byte[])times.LogoTimes);
                pictureBox1.Image = Image.FromStream(ms);
            }

            catch (Exception)
            {

            }

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            times.CodTimes = Convert.ToInt32(tbxCodigoTimes.Text);

            if (tbxCodigoTimes.Text == "")
            {
                MessageBox.Show("Digite um número válido");
                return;
            }


           var resposta = MessageBox.Show("Deseja excluir o Time" + tbxCodigoTimes.Text + "?",
            "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (resposta == DialogResult.Yes) 
            {
                times.CodTimes = Convert.ToInt32(tbxCodigoTimes.Text);

                manipulaTimes manipulaTimes = new manipulaTimes();
                manipulaTimes.deletarTimes();
            }
            
                lblCodigoTime.Text = string.Empty;
                tbxTime.Text = string.Empty;
                tbxFrase.Text = string.Empty;
                tbxCodigoTimes.Text = string.Empty;
                pictureBox1.Image = null;


        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if(lblCodigoTime.Text == "")
            {
                MessageBox.Show("Digite um Codigo Válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     
                    
                lblCodigoTime.Text = string.Empty;
                tbxTime.Text = string.Empty;
                tbxFrase.Text = string.Empty;
                tbxCodigoTimes.Text = string.Empty;
                pictureBox1.Image = null;
                return;

            }

            var resposta = MessageBox.Show(" Deseja fazer as alterações no time " + lblCodigoTime.Text + "?","Atenção!", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if(resposta == DialogResult.Yes)
            {
                times.CodTimes = Convert.ToInt32(lblCodigoTime.Text);
                times.NomeTimes = tbxTime.Text;
                times.FraseTimes = tbxFrase.Text;
                MemoryStream memoriaLogo = new MemoryStream();
                pictureBox1.Image.Save(memoriaLogo, pictureBox1.Image.RawFormat);
                times.LogoTimes = memoriaLogo.ToArray();

                manipulaTimes manipulaTimes = new manipulaTimes();
                manipulaTimes.alterarTimes();


                    
            }
        }

        private void btnAlterarImagem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Escolha seu logo(*.jpg; *jpeg; *.png;)" + "| *.jpg; *jpeg; *.png;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);



            }
        }
    }


}
