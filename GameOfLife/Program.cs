using GameOfLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        const int SZEROKOSC = 150;
        const int WYSOKOSC = 50;
        const int CZAS = 200;
        const int ZYWYCH = (int)(SZEROKOSC*WYSOKOSC*0.2);
        public static Plansza plansza;

        static void Main(string[] args)
        {
            //Console.OutputEncoding = Encoding.Unicode.Ut
            plansza = new Plansza(SZEROKOSC, WYSOKOSC, ZYWYCH);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(plansza);

            while (true)
            {
                //Console.ReadKey();
                plansza.NextStep();
                Console.Clear();
                Console.Write(plansza);
                Thread.Sleep(CZAS);
            }
        }


    }
}
