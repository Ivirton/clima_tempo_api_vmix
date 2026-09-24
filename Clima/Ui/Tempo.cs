using Clima.Data;
using Clima.Lib;
using Clima.Properties;
using System;
using System.Drawing.Imaging;
using System.IO;

using System.Windows.Forms;

namespace Clima
{
    public partial class Tempo : Form
    {
        public Tempo()
        {
            InitializeComponent();
            carregarUrlComo();
         
            // VERIFICA SE NO DIRETORIO EXISTE O ARQUICO CASO CONTRARIO ELE CRIA
            if (!File.Exists(@"C:\Tempo\Icon\01.png"))
            {
                System.IO.Directory.CreateDirectory(@"C:\Tempo\Icon\");
                Resources._01.Save(@"C:\Tempo\Icon\01.png", ImageFormat.Png);
                Resources._02.Save(@"C:\Tempo\Icon\02.png", ImageFormat.Png);
                Resources._03.Save(@"C:\Tempo\Icon\03.png", ImageFormat.Png);
                Resources._04.Save(@"C:\Tempo\Icon\04.png", ImageFormat.Png);
                Resources._05.Save(@"C:\Tempo\Icon\05.png", ImageFormat.Png);
                Resources._06.Save(@"C:\Tempo\Icon\06.png", ImageFormat.Png);
                Resources._07.Save(@"C:\Tempo\Icon\07.png", ImageFormat.Png);
                Resources._08.Save(@"C:\Tempo\Icon\08.png", ImageFormat.Png);
            }
        }
       
        
        private void VerificarIconeTempo()
        {

        }
        private void adcionarCidade1(object sender, EventArgs e)
        {
            try
            {
                Cidade cidade = new Cidade(comboBox1.Text);
                dataGridView1.Rows.Add(cidade.nome, cidade.indice, cidade.temMin, cidade.temMax, cidade.umidMin + "  |  " + cidade.umdMax, cidade.vento);
                Cidade.cidades01.Add(cidade);
                adcionarUrlCombo(comboBox1.Text);
            }
            catch (Exception)
            {
                
            }
            finally
            {
                
            }
        }
        private void adcionarCidade2_Click(object sender, EventArgs e)
        {
            try
            {
                Cidade cidade = new Cidade(comboBox2.Text);
                dataGridView2.Rows.Add(cidade.nome, cidade.indice, cidade.temMin, cidade.temMax, cidade.umidMin + "  |  " + cidade.umdMax, cidade.vento);
                Cidade.cidades02.Add(cidade);
                adcionarUrlCombo(comboBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("ERRO DE CONECÃO");
                Dispose();
            }
            finally
            {
                
            }
        }
        public void adcionarUrlCombo(string url)
        {
     
            if (!AppConfiguration.Default.comboUrl.Contains(url))
            {
                if (url != "")
                {
                    AppConfiguration.Default.comboUrl.Add(url);
                    AppConfiguration.Default.Save();
                }
            }
           
        }
        public void carregarUrlComo()
        {
            try
            {
                for (int c = 0; c < AppConfiguration.Default.comboUrl.Count; c++)
                {
                    if (AppConfiguration.Default.comboUrl[c] != "")
                    {
                        comboBox1.Items.Add(AppConfiguration.Default.comboUrl[c]);
                        comboBox2.Items.Add(AppConfiguration.Default.comboUrl[c]);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        #region setApiCidade
        private void dataGridView1_Click(object sender, EventArgs e)
        {

            try
            {
                var position = dataGridView1.CurrentCell.RowIndex;
                Cidade.cidades01[position].setApiText(Cidade.cidades01[position].nome, "NOME%20CIDADE01.Text");
                Cidade.cidades01[position].setApiText(Cidade.cidades01[position].temMin, "Mini01.Text");
                Cidade.cidades01[position].setApiText(Cidade.cidades01[position].temMax, "Max01.Text");
                Cidade.cidades01[position].setApiText(Cidade.cidades01[position].umidMin, "HumiMin01.Text");
                Cidade.cidades01[position].setApiText(Cidade.cidades01[position].umdMax, "HumiMax01.Text");
                Cidade.cidades01[position].setApiText(Cidade.cidades01[position].vento, "Vento01.Text");
                Cidade.cidades01[position].setApiText(Cidade.cidades01[position].indice, "probabilidade01.Text");
                Cidade.cidades01[position].setApiImage(Cidade.cidades01[position].imagem, "ImageClima01.Source");
                pictureBox1.Image = Cidade.cidades01[position].imagemCidade.resoucesImagen;
            }
            catch (Exception )
            {
               
               
            }
            finally
            {
               
            }
        }
        private void dataGridView2_Click(object sender, EventArgs e)
        {
            try
            {
                var position = dataGridView2.CurrentCell.RowIndex;
                Cidade.cidades02[position].setApiText(Cidade.cidades02[position].nome, "NOME%20CIDADE02.Text");
                Cidade.cidades02[position].setApiText(Cidade.cidades02[position].temMin, "Mini02.Text");
                Cidade.cidades02[position].setApiText(Cidade.cidades02[position].temMax, "Max02.Text");
                Cidade.cidades02[position].setApiText(Cidade.cidades02[position].umidMin, "HumiMin02.Text");
                Cidade.cidades02[position].setApiText(Cidade.cidades02[position].umdMax, "HumiMax02.Text");
                Cidade.cidades02[position].setApiText(Cidade.cidades02[position].vento, "Vento02.Text");
                Cidade.cidades02[position].setApiText(Cidade.cidades02[position].indice, "probabilidade02.Text");
                Cidade.cidades02[position].setApiImage(Cidade.cidades02[position].imagem, "ImageClima02.Source");
                pictureBox2.Image = Cidade.cidades02[position].imagemCidade.resoucesImagen;
            }
            catch (Exception)
            {
               
            }
            finally
            {
               
            }
        }
        #endregion
        private void buttonConfiguration_Click(object sender, EventArgs e)
        {
            new Ui.Configuration().ShowDialog();
        }
        private void carregarCidades_Click(object sender, EventArgs e)
        {

            carregar();
        }
        public void carregar()
        {

            ListBox listBox = new ListBox();
            progressBar1.Visible = true;
            aTIVARToolStripMenuItem.Enabled = false;
            progressBar1.Maximum = AppConfiguration.Default.listaCidades.Count;
            try
            {
                for (int c = 0; c < AppConfiguration.Default.listaCidades.Count; c++)
                {

                    Lib.TempoAgora tempoAgora = new TempoAgora(AppConfiguration.Default.listaCidades[c]);
                    listBox.Items.Add(tempoAgora.nomeCidade + " " + tempoAgora.tempoAgora);
                    progressBar1.Value++;
                }
            }
            catch (Exception)
            {

            }
            listBoxCidades.Items.Clear();
            listBoxCidades.Items.AddRange(listBox.Items);
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            aTIVARToolStripMenuItem.Enabled = true;
           
        }
        private void ativarTimer(object sender, EventArgs e)
        {
            switch (timerApi.Enabled)
            {
                case true:
                    timerApi.Enabled = false;
                   // carregarCidades.Enabled = true;
                    aTIVARToolStripMenuItem.Checked = false;
                    aTIVARToolStripMenuItem.Text = "ATIVAR";
                    break;
                        case false:
                    timerApi.Enabled = true;
                   // carregarCidades.Enabled = false;
                    aTIVARToolStripMenuItem.Checked = true;
                    aTIVARToolStripMenuItem.Text = "DESATIVAR";
                    break;
            }
        }
        private void setTimerApi(object sender, EventArgs e)
        {
            if(TempoAgora.nun == listBoxCidades.Items.Count)
            {
                TempoAgora.nun = 0;
            }
            TempoAgora.setApiText(listBoxCidades.Items[TempoAgora.nun].ToString());
            listBoxCidades.SelectedIndex = TempoAgora.nun;
            TempoAgora.nun++;

            

        }

      
    }
}
