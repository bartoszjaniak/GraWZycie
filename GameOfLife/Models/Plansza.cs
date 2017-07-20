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
        List<Byt> lista;

        static readonly string[] Generator = new string[]
            {
              "                        1           ",
              "                      1 1           ",
              "            11      11            11",
              "           1   1    11            11",
              "11        1     1   11              ",
              "11        1   1 11    1 1           ",
              "          1     1       1           ",
              "           1   1                    ",
              "            11                      "
            };

        public Plansza(int szer, int wys, bool losowo = true, int iloscZywych = 10)
        {
            wysokosc = wys;
            szerokosc = szer;
            byty = new Byt[szerokosc, wysokosc];
            lista = new List<Byt>();

            

            for (int i = 0; i < szerokosc; i++)
            {
                for (int k = 0; k < wysokosc; k++)
                {
                    byty[i, k] = new Byt();
                    lista.Add(new Byt(i, k));
                }
            }

            if (losowo)
                GenerujLosowe(iloscZywych);
            else Generate(Generator, szerokosc, wysokosc);
        }

        private void GenerujLosowe(int ilosc)
        {
            Random r = new Random();
            for (int i = 0; i < ilosc; i++)
            {
                int x = r.Next(szerokosc);
                int y = r.Next(wysokosc);
                byty[x, y].Ozyw();
            }
        }

        private void Generate(string[] pattern, int sx, int sy)
        {
            for (int y = 0; y < pattern.Length; y++)
            {
                for (int x = 0; x < pattern[y].Length; x++)
                    if (pattern[y][x] != ' ')
                        this.byty[sx + x, sy + y].Ozyw();
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
            for (int i = 0; i < wysokosc; i++)
            {
                for (int k = 0; k < szerokosc; k++)
                {
                    //sprawdzanie sąsiadów
                    int iloscSasiadow = slg(k, i) + ssg(k, i) + spg(k, i) + sl(k, i) + sp(k, i) + sld(k, i) + ssd(k, i) + spd(k, i);
                    
                    //ZABIJANIE I OŻYWIANIE
                    if (bytyTemp[i, k].zywa != 1 && iloscSasiadow == 3) 
                        byty[i, k].Ozyw();
                    if (bytyTemp[i, k].zywa == 1 && (iloscSasiadow < 2 || iloscSasiadow > 3)) 
                        byty[i, k].Ubij();

                }
            }
        }

        //public void NextStep2()
        //{
        //    int ilosc;
        //    foreach (var a in lista)
        //    {
        //        int iloscSasiadow = slg(k, i) + ssg(k, i) + spg(k, i) + sl(k, i) + sp(k, i) + sld(k, i) + ssd(k, i) + spd(k, i);                    
        //    }
        //}

        3


        #region sprawdzanie sasiadów
        //lewa góra
        private int slg(int x, int y)
        {
            return byty[validateSzer(x) - 1, validateWys(y) - 1].zywa;
        }
        //środek góra
        private int ssg(int x, int y)
        {
            return byty[validateSzer(x), validateWys(y) - 1].zywa;
        }
        //prawa góra
        private int spg(int x, int y)
        {
            return byty[validateSzer(x) + 1, validateWys(y) - 1].zywa;
        }
        
        //lewa
        private int sl(int x, int y)
        {
            return byty[validateSzer(x) - 1, validateWys(y)].zywa;
        }
        //prawa
        private int sp(int x, int y)
        {
            return byty[validateSzer(x) + 1, validateWys(y)].zywa;
        }

        //lewa dol
        private int sld(int x, int y)
        {
            return byty[validateSzer(x) - 1, validateWys(y) + 1].zywa;
        }
        //środek dol
        private int ssd(int x, int y)
        {
            return byty[validateSzer(x), validateWys(y) + 1].zywa;
        }
        //prawa dol
        private int spd(int x, int y)
        {
            return byty[validateSzer(x) + 1, validateWys(y) + 1].zywa;
        }
        #endregion

        //WALIDACJA WYSOKOSCI
        private int validateWys(int y)
        {
            return Math.Max(Math.Min(y, wysokosc - 2), 1);
        }

        //WALIDACJA SZEROKOSCI
        private int validateSzer(int x)
        {
            return Math.Max(Math.Min(x, szerokosc - 2), 1);
        }

    }
}
