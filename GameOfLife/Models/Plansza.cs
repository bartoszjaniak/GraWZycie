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
        Byt[,] bytyTemp;

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

        static readonly string[] Generator2 = new string[]
        {
              "                                    ",
              "      1                             ",
              "       1           1                ",
              "     111            1               ",
              "                  111               ",
              "                                    ",
              "                                    ",
              "                                    "
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
            else Generate(Generator, 5, 5);
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

        public void Drukuj(Byt[,] tabelka = null)
        {
            Console.Clear();
            if (tabelka == null) tabelka = byty;
            string A = "";
            for (int i = 0; i < wysokosc; i++)
            {
                Console.Write('\n');
                for (int k = 0; k < szerokosc; k++)
                {
                    if (tabelka[k, i].zywa == 1)
                        Console.BackgroundColor = ConsoleColor.Green;
                    else
                        Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(tabelka[k, i]);

                }
            }
        }

        public override string ToString()
        {
            Console.Clear();
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
            bytyTemp = new Byt[szerokosc, wysokosc];
            for (int x = 0; x < szerokosc; x++)
            {
                for (int y = 0; y < wysokosc; y++)
                {
                    bytyTemp[x, y] = new Byt();
                    bytyTemp[x, y].zywa = byty[x, y].zywa;
                }
            }
                    //byty = new Byt[szerokosc, wysokosc];
            for (int x = 0; x < szerokosc; x++)
            {
                for (int y = 0; y < wysokosc; y++)
                {
                    //sprawdzanie sąsiadów
                    int iloscSasiadow = slg(x, y) + ssg(x, y) + spg(x, y) + sl(x, y) + sp(x, y) + sld(x, y) + ssd(x, y) + spd(x, y);

                    ////sprawdzanie sąsiadów
                    //int iloscSasiadow = 0;

                    ////lewa
                    //if (x > 0 && y > 0 && bytyTemp[x - 1, y - 1].zywa == 1)
                    //    iloscSasiadow++;
                    //if (x > 0 && bytyTemp[x - 1, y].zywa == 1)
                    //    iloscSasiadow++;
                    //if (x > 0 && y < wysokosc - 1 && bytyTemp[x - 1, y + 1].zywa == 1)
                    //    iloscSasiadow++;

                    ////srodek
                    //if (y > 0 && bytyTemp[x, y - 1].zywa == 1)
                    //    iloscSasiadow++;
                    //if (y < wysokosc - 1 && bytyTemp[x, y + 1].zywa == 1)
                    //    iloscSasiadow++;

                    ////prawa
                    //if (x < szerokosc - 1 && y > 0 && bytyTemp[x + 1, y - 1].zywa == 1) iloscSasiadow++;
                    //if (x < szerokosc - 1 && bytyTemp[x + 1, y].zywa == 1) iloscSasiadow++;
                    //if (x < szerokosc - 1 && y < wysokosc - 1 && bytyTemp[x + 1, y + 1].zywa == 1) iloscSasiadow++;






                    //if ((i > 0 && k > 0) && bytyTemp[i - 1, k - 1].zywa == 1) iloscSasiadow++;
                    //if ((i > 0) && k == 0 && bytyTemp[i - 1, k].zywa == 1) iloscSasiadow++;
                    //if ((i > 0 && k < wysokosc-1 && k > 0) && bytyTemp[i - 1, k + 1].zywa == 1) iloscSasiadow++;

                    //if ((k > 0) && bytyTemp[i, k - 1].zywa == 1) iloscSasiadow++;
                    //if ((k < wysokosc - 1) && bytyTemp[i, k + 1].zywa == 1) iloscSasiadow++;

                    //if ((i < szerokosc - 1 && k > 0) && bytyTemp[i + 1, k - 1].zywa == 1) iloscSasiadow++;
                    //if ((i < szerokosc - 1) && bytyTemp[i + 1, k].zywa == 1) iloscSasiadow++;
                    //if ((i < szerokosc - 1 && k < wysokosc - 1) && bytyTemp[i + 1, k + 1].zywa == 1) iloscSasiadow++;


                    byty[x, y].iloscSasiadow = iloscSasiadow;
                    //ZABIJANIE I OŻYWIANIE
                    //Drukuj(bytyTemp);
                     if (bytyTemp[x, y].zywa != 1 && iloscSasiadow == 3) 
                        byty[x, y].Ozyw();
                    if (bytyTemp[x, y].zywa == 1 && (iloscSasiadow < 2 || iloscSasiadow > 3)) 
                        byty[x, y].Ubij();

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

        
    

        #region sprawdzanie sasiadów
        //lewa góra
        private int slg(int x, int y)
        {
            return bytyTemp[validateSzer(x - 1), validateWys(y - 1)].zywa;
        }
        //środek góra
        private int ssg(int x, int y)
        {
            return bytyTemp[validateSzer(x), validateWys(y - 1)].zywa;
        }
        //prawa góra
        private int spg(int x, int y)
        {
            return bytyTemp[validateSzer(x + 1), validateWys(y - 1)].zywa;
        }
        
        //lewa
        private int sl(int x, int y)
        {
            return bytyTemp[validateSzer(x - 1), validateWys(y)].zywa;
        }
        //prawa
        private int sp(int x, int y)
        {
            return bytyTemp[validateSzer(x + 1), validateWys(y)].zywa;
        }

        //lewa dol
        private int sld(int x, int y)
        {
            return bytyTemp[validateSzer(x - 1), validateWys(y + 1)].zywa;
        }
        //środek dol
        private int ssd(int x, int y)
        {
            return bytyTemp[validateSzer(x), validateWys(y + 1)].zywa;
        }
        //prawa dol
        private int spd(int x, int y)
        {
            return bytyTemp[validateSzer(x + 1), validateWys(y + 1)].zywa;
        }
        #endregion

        //WALIDACJA WYSOKOSCI
        private int validateWys(int y)
        {
            if (y < 0) return wysokosc-1;
            if (y == wysokosc) return 0;
            return y;
            //return Math.Max(Math.Min(y, wysokosc - 1), 0);
        }

        //WALIDACJA SZEROKOSCI
        private int validateSzer(int x)
        {
            if (x < 0) return szerokosc-1;
            if (x == szerokosc) return 0;
            return x;
           // return Math.Max(Math.Min(x, szerokosc - 1), 0);
        }

    }
}
