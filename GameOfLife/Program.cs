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
        const int CZAS = 10;
        const int ZYWYCH = (int)(SZEROKOSC*WYSOKOSC*0.1);
        public static Plansza plansza;

        static void Main(string[] args)
        {
            //Console.OutputEncoding = Encoding.Unicode.Ut
           //plansza = new Plansza(SZEROKOSC, WYSOKOSC,true,ZYWYCH);
            plansza = new Plansza(SZEROKOSC, WYSOKOSC, false);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(plansza);

            int i = 0;
            while (true)
            {
                //Console.ReadKey();
                
                
                Console.Write(plansza);
                //plansza.Drukuj();
                Console.WriteLine(i);
                //Console.ReadKey();
                plansza.NextStep();
                i++;
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