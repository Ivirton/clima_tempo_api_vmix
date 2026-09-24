using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clima.Data;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Clima.Lib
{
    class Cidade
    {

      
        public Cidade(string url)
        {
            urlCurto = url;
            inicialazer();
            htmlDocument.LoadHtml(webClient.DownloadString(urlBase + urlCurto));
            procurarDados();
           
            
        }
      
        private void procurarDados()
        {
           
                nome = htmlDocument.DocumentNode.SelectSingleNode(Data.Xpath.Default.nome).InnerText.Trim().Replace("- MA", "").ToUpper();
                indice = htmlDocument.DocumentNode.SelectSingleNode(Data.Xpath.Default.indice).InnerText;
                vento = htmlDocument.DocumentNode.SelectSingleNode(Data.Xpath.Default.vento).InnerText.Trim();
                temMin = htmlDocument.GetElementbyId(Data.Xpath.Default.min).InnerText;
                temMax = htmlDocument.GetElementbyId(Data.Xpath.Default.max).InnerText;
                umidMin = htmlDocument.DocumentNode.SelectSingleNode(Data.Xpath.Default.umdMin).InnerText;
                umdMax = htmlDocument.DocumentNode.SelectSingleNode(Data.Xpath.Default.umdMax).InnerText;
                status = htmlDocument.DocumentNode.SelectNodes(Data.Xpath.Default.status)[0].ChildNodes[8].InnerText.Trim();
                imagemCidade.escolherImagem(status);
                imagem = imagemCidade.image;
               
               
           
        }

        public string setApiText(string value, string selandName)
        {
            try
            {
               return webClient.DownloadString(Api.Default.ipVmix + "/API/?Function=SetText&Input=" + Api.Default.gcInput + "&Value="+ value+ "&SelectedName=" + selandName);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "Erro";
            }
            finally
            {
               
            }
        }
        public string setApiImage(string value, string selandName)
        {
            try
            {
               return webClient.DownloadString(Api.Default.ipVmix + "/API/?Function=SetImage&Input=" + Api.Default.gcInput + "&Value=" +Api.Default.directImagem + value + "&SelectedName=" + selandName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "Erro";
            }
            finally
            {
              
            }
        }



        #region Propriedades
        public void inicialazer()
        {
            webClient = new WebClient();
            htmlDocument = new HtmlDocument();
            webClient.Encoding = Encoding.UTF8;
            imagemCidade = new Imagem();

        }
       
        public static List<Cidade> cidades01 = new List<Cidade>();
        public static List<Cidade> cidades02 = new List<Cidade>();

        public string nome = null;
        public string temMin = null;
        public string temMax = null;
        public string vento = null;
        public string umidMin = null;
        public string umdMax = null;
        public string indice = null;
        public string status = null;
        public string imagem = null;
        private string urlCurto = null;
        WebClient webClient;
        HtmlDocument htmlDocument;
       public  Imagem imagemCidade;
        private const string urlBase = "https://www.climatempo.com.br/previsao-do-tempo/cidade/";
        #endregion
    }
}
