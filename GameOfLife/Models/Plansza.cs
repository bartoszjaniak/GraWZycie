using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    class Plansza
    {
        public int szerokosc;
        public int wysokosc;
        public Byt[,] byty;

        public Plansza(int szer, int wys, int iloscZywych = 10)
        {
            wysokosc = wys;
            szerokosc = szer;
            byty = new Byt[szerokosc, wysokosc];
            for(int i = 0; i < szerokosc; i++)
            {
                for(int k = 0; k < wysokosc; k++)
                {
                    byty[i, k] = new Byt();
                }
            }
            GenerujLosowe(iloscZywych);
        }

        private void GenerujLosowe(int ilosc)
        {
            Random r = new Random();
            for(int i = 0; i < ilosc; i++)
            {
                int x = r.Next(szerokosc);
                int y = r.Next(wysokosc);
                byty[x, y].Ozyw();
            }
        }

        public override string ToString()
        {
            string A = "";
            for (int i = 0; i < wysokosc; i++)
            {
                A += '\n';
                for (int k = 0; k < szerokosc; k++)
                {
                    A += byty[k, i];

                }
            }
            return A;
        }

        public void NextStep()
        {
            Byt[,] bytyTemp = byty;
            //byty = new Byt[szerokosc, wysokosc];
            for (int i = 0; i < szerokosc; i++)
            {
                for (int k = 0; k < wysokosc; k++)
                {
                    //sprawdzanie sąsiadów
                    int iloscSasiadow = 0;
                    if ((i > 0 && k > 0) && bytyTemp[i - 1, k - 1].zywa) iloscSasiadow++;
                    if ((i > 0) && bytyTemp[i - 1, k].zywa) iloscSasiadow++;
                    if ((i > 0 && k <wysokosc - 1) && bytyTemp[i - 1, k + 1].zywa) iloscSasiadow++;

                    if ((k > 0) && bytyTemp[i, k - 1].zywa) iloscSasiadow++;
                    if ((k < wysokosc - 1) && bytyTemp[i, k + 1].zywa) iloscSasiadow++;

                    if ((i < szerokosc - 1 && k > 0) && bytyTemp[i + 1, k - 1].zywa) iloscSasiadow++;
                    if ((i < szerokosc - 1) && bytyTemp[i + 1, k].zywa) iloscSasiadow++;
                    if ((i < szerokosc - 1 && k< wysokosc - 1) && bytyTemp[i + 1, k + 1].zywa) iloscSasiadow++;

                    if (bytyTemp[i, k].zywa && (iloscSasiadow < 2 || iloscSasiadow > 3)) byty[i, k].Ubij();
                    else if (!bytyTemp[i, k].zywa &&  iloscSasiadow == 3) byty[i, k].Ozyw();
                }
            }

        }


    }
}
