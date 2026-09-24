using Clima.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clima.Ui
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
            carregarDados();
        }

     

        private void buttonRedefinir_Click(object sender, EventArgs e)
        {
            Data.Api.Default.Reset();
            Data.AppConfiguration.Default.Reset();
            Data.Xpath.Default.Reset();
            carregarDados();
        }

        private void salvarDados(object sender, EventArgs e)
        {
            Data.Api.Default.Save();
            Data.AppConfiguration.Default.Save();
            Data.Xpath.Default.Save();
            SalvarCampos();
        }



        public void carregarDados()
        {
            climaNome.Text = Xpath.Default.nome;
            climaIndice.Text = Xpath.Default.indice;
            climaUmidadeMinima.Text = Xpath.Default.umdMin;
            climaUmidadeMaxima.Text = Xpath.Default.umdMax;
            climaVento.Text = Xpath.Default.vento;
            climaStatus.Text = Xpath.Default.status;
            nomeAgora.Text = Xpath.Default.nomeAgora;
            tempoAgora.Text = Xpath.Default.tempoAgora;
            ipVmix.Text = Data.Api.Default.ipVmix;
        }
        public void SalvarCampos()
        {

            if (climaNome.Text != "") Xpath.Default.nome = climaNome.Text;
            if (climaIndice.Text != "") Xpath.Default.indice = climaIndice.Text;
            if (climaUmidadeMinima.Text != "") Xpath.Default.umdMin = climaUmidadeMinima.Text;
            if (climaUmidadeMaxima.Text != "") Xpath.Default.umdMax = climaUmidadeMaxima.Text;
            if (climaVento.Text != "") Xpath.Default.vento = climaVento.Text;
            if (climaStatus.Text != "") Xpath.Default.status = climaStatus.Text;
            if (nomeAgora.Text != "") Xpath.Default.nomeAgora = nomeAgora.Text;
            if (tempoAgora.Text != "") Xpath.Default.tempoAgora = tempoAgora.Text;
            if (ipVmix.Text != "") Data.Api.Default.ipVmix = ipVmix.Text;


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
