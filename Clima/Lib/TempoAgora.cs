using Clima.Data;
using Clima.Properties;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clima.Lib
{
    class TempoAgora
    {
        // MÉTODO CONTRUTOR 
        public TempoAgora( string url) 
        {
            urlCurto = url;
            inicializador();
            var dado = webClient.DownloadString(urlBase + urlCurto);
            htmlDocument.LoadHtml(dado);
            procurarDados();
        }

        // MÉTODO RAPAGEM DE COLETA DE DADOS 
        public void procurarDados() 
        {  
                nomeCidade = htmlDocument.DocumentNode.SelectSingleNode("//*[@class='" + Xpath.Default.nomeAgora + "']").FirstChild.InnerText.Replace(", MA", "").Trim();
                tempoAgora = htmlDocument.DocumentNode.SelectSingleNode("//*[@class='" + Xpath.Default.tempoAgora + "']").FirstChild.InnerText.Trim();
        }
        // MÉTODO DE PASSAGEM DE PARÁMETRO VIA API DO VMIX
        public static void setApiText(string value)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadString(Api.Default.ipVmix + "/API/?Function=SetText&Input=GC - HORA E CLIMA.gtzip&Value=" + value + "&SelectedName=CLIMA.Text");
        }

        #region PROPRIEDADES DO OBJETO
        WebClient webClient;
        HtmlDocument htmlDocument;
        public  string tempoAgora = null;
        public string nomeCidade = null;
        string urlCurto = null;
        private const string urlBase = "https://www.climatempo.com.br/previsao-do-tempo/agora/cidade/";
        public static int nun = 0;
        // MÉTODO PARA INICIALIZAR OS COMPONENTES E OJETOS DA CLASSE
        public void inicializador()
        {
            webClient = new WebClient();
            htmlDocument = new HtmlDocument();
            webClient.Encoding = Encoding.UTF8;
        }
        #endregion
    }


}
