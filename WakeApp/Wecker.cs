using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeApp
{
    internal class Wecker
    {
        private int result;

        public void Einstellen()
        {
            DateTime wecker = DateTime.Parse(Program.ankunftszeit);
            double addierteZeit = Convert.ToInt32(Program.fahrtzeit) + Convert.ToInt32(Program.fertigmachzeit) + Convert.ToInt32(Program.weitereZeit);
            wecker = wecker.AddMinutes(-addierteZeit);

            result = DateTime.Compare(wecker, DateTime.Now);
            if (result <= 0)
            {
                wecker = wecker.AddDays(1);
            }

            Console.WriteLine(addierteZeit + " " + -addierteZeit + " " + wecker);
            Console.ReadKey();

            TimeSpan uebrigeZeit;
            TimeSpan nullZeit = new TimeSpan(0, 0, 0);

            Console.Clear();
            Program.Ueberschrift();
            Console.WriteLine("Wecker klingelt in:");
            do
            {
                uebrigeZeit = wecker - DateTime.Now;
                result = TimeSpan.Compare(uebrigeZeit, nullZeit);

                Console.SetCursorPosition(0, 2);
                Console.WriteLine(uebrigeZeit.ToString(@"dd\:hh\:mm\:ss"));
                System.Threading.Thread.Sleep(1000);
            }
            while (result >= 0);

            Console.WriteLine("Die Weckerzeit wurde erreicht!");
        }
    }
}
