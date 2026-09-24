using Clima.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clima.Lib
{
    class Imagem
    {

        public Imagem(string st)
        {
            status = st;
        }
        public Imagem()
        {

        }

       public string image;

       public Image resoucesImagen;
        public void escolherImagem(string status)
        {
            switch (status)
            {
                case "Sol e aumento de nuvens de manhã. Pancadas de chuva à tarde e à noite.":
                    image = "08.png";
                    resoucesImagen = Resources._08;
                    break;
                case "Sol com algumas nuvens. Não chove.":
                    image = "01.png";
                    resoucesImagen = Resources._01;
                    break;
                case "Dia de sol com algumas nuvens e névoa ao amanhecer. Noite com poucas nuvens.":
                    image = "06.png";
                    resoucesImagen = Resources._06;
                    break;
                case "Sol com algumas nuvens. Chove rápido durante o dia e à noite.":
                    image = "07.png";
                    resoucesImagen = Resources._07;
                    break;
                case "Dia de sol, com geada ao amanhecer. As nuvens aumentam no decorrer da tarde.":
                    image = "05.png";
                    resoucesImagen = Resources._05;
                    break;
                case "Céu nublado com possibilidade de garoa o dia todo. À noite as nuvens diminuem devagar.":
                    image = "06.png";
                    resoucesImagen = Resources._06;
                    break;
                case "Sol com muitas nuvens durante o dia e períodos de céu nublado. Noite com muitas nuvens.":
                    image = "06.png";
                    resoucesImagen = Resources._06;
                    break;
                case "Sol com muitas nuvens. Pancadas de chuva à tarde e à noite.":
                    image = "08.png";
                    resoucesImagen = Resources._08;
                    break;
                case "Sol e aumento de nuvens de manhã. Pancadas de chuva à tarde. À noite o tempo fica aberto.":
                    image = "03.png";
                    resoucesImagen = Resources._03;
                    break;

                  
                default:
                    image = "02.png";
                    resoucesImagen = Resources._02;
                    break;
            }

        } 
        private string status = null;
    }
}
