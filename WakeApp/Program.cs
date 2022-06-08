using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeApp
{
    class Program
    {
        public static bool appLaeuft = true;
        public static bool csvLeer = false;
        public static bool neuerWecker = false;

        public static string ankunftszeit;
        public static string fahrtzeit;
        public static string fertigmachzeit;
        public static string weitereZeit;

        private static string eingabe;
        private static int eingabeTest;
        static void Main(string[] args)
        {
            Console.Title = "WakeApp";
            CsvDatei Csv = new CsvDatei();
            Wecker Wecker = new Wecker();
            Csv.Abrufen();

            do
            {
                if (csvLeer || neuerWecker)
                {
                    Console.Clear();
                    Ueberschrift();
                    Console.WriteLine("Neuen Wecker anlegen...");

                    // Ankunftszeit
                    DateTime dateTime;
                    Console.WriteLine("Die gewünschte Ankunftszeit: (HH:mm)");
                    do
                    {
                        Console.SetCursorPosition(0, 3);
                        Console.Write("                                              ");
                        Console.SetCursorPosition(0, 3);
                        eingabe = Console.ReadLine();
                    }
                    while (!DateTime.TryParse(eingabe, out dateTime));
                    ankunftszeit = eingabe;

                    // Fahrtzeit
                    Console.WriteLine("Die gewünschte Fahrtzeit: (in Minuten)");
                    do
                    {
                        Console.SetCursorPosition(0, 5);
                        Console.Write("                                              ");
                        Console.SetCursorPosition(0, 5);
                        eingabe = Console.ReadLine();
                    }
                    while (!int.TryParse(eingabe, out eingabeTest));
                    fahrtzeit = eingabe;

                    // Fertigmachzeit
                    Console.WriteLine("Die gewünschte Fertigmachzeit: (in Minuten)");
                    do
                    {
                        Console.SetCursorPosition(0, 7);
                        Console.Write("                                              ");
                        Console.SetCursorPosition(0, 7);
                        eingabe = Console.ReadLine();
                    }
                    while (!int.TryParse(eingabe, out eingabeTest));
                    fertigmachzeit = eingabe;

                    // Weitere Verzögerung
                    Console.WriteLine("Weitere Verzögerungen die auftreten können: (in Minuten)");
                    do
                    {
                        Console.SetCursorPosition(0, 9);
                        Console.Write("                                              ");
                        Console.SetCursorPosition(0, 9);
                        eingabe = Console.ReadLine();
                    }
                    while (!int.TryParse(eingabe, out eingabeTest));
                    weitereZeit = eingabe;

                    Csv.Speichern();
                    Wecker.Einstellen();

                    Console.WriteLine("Wollen sie einen neuen Wecker erstellen?");
                    do
                    {
                        Console.SetCursorPosition(0, 5);
                        Console.Write("                                              ");
                        Console.SetCursorPosition(0, 5);
                        eingabe = Console.ReadLine();
                    }
                    while (eingabe.ToLower() != "ja" & eingabe.ToLower() != "nein");
                    if (eingabe.ToLower().Equals("nein"))
                    {
                        appLaeuft = false;
                    }
                }
                else
                {
                    do
                    {
                        Console.Clear();
                        Ueberschrift();
                        Console.WriteLine("Es konnten Werte eingelesen werden. Sollen diese Werte übernommen werden?");
                        Console.SetCursorPosition(0, 2);
                        eingabe = Console.ReadLine();
                    }
                    while (eingabe.ToLower() != "ja" & eingabe.ToLower() != "nein");

                    switch (eingabe.ToLower())
                    {
                        case "ja":
                            Wecker.Einstellen();
                            Console.WriteLine("Wollen sie einen neuen Wecker erstellen?");
                            do
                            {
                                Console.SetCursorPosition(0, 5);
                                Console.Write("                                              ");
                                Console.SetCursorPosition(0, 5);
                                eingabe = Console.ReadLine();
                            }
                            while (eingabe.ToLower() != "ja" & eingabe.ToLower() != "nein");
                            if (eingabe.ToLower().Equals("ja"))
                            {
                                neuerWecker = true;
                            }
                            else if (eingabe.ToLower().Equals("nein"))
                            {
                                appLaeuft = false;
                            }
                            break;
                        case "nein":
                            neuerWecker = true;
                            break;
                    }
                }
            }
            while (appLaeuft);
        }

        public static void Ueberschrift()
        {
            Console.WriteLine("WakeApp-Konsolenanwendung!");
        }
    }
}
