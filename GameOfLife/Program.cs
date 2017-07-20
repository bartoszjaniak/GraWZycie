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
        const int SZEROKOSC = 50;
        const int WYSOKOSC = 50;
        const int CZAS = 200;
        const int ZYWYCH = (int)(SZEROKOSC*WYSOKOSC*0.1);
        public static Plansza plansza;

        static void Main(string[] args)
        {
            //Console.OutputEncoding = Encoding.Unicode.Ut
            plansza = new Plansza(SZEROKOSC, WYSOKOSC,true,ZYWYCH);
            //plansza = new Plansza(SZEROKOSC, WYSOKOSC, false);
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



/*
 * SOFT
 * 1) Nie używać if,while,switch, ?:
 * 2) Każda metoda musi mieć jak najmniej lini
 * 3) Jak najmniej kliknięć myszką
 * 
 * Hard
 * 1) 1 + foreach
 * 2) 2 + Max 2 linie 
 * 3) Bez myszki
 * 
 * 
*/