using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WakeApp
{
    internal class CsvDatei
    {
        private string projektOrdner = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private string csvDatei = @"\wecker.csv";
        public void Abrufen()
        {
            if (!File.Exists(projektOrdner + csvDatei))
            {
                File.Create(projektOrdner + csvDatei);
            }

            if (File.ReadAllLines(projektOrdner + csvDatei).Length < 0)
            {
                Program.csvLeer = true;
            }
            else
            {
                StreamReader reader = new StreamReader(File.OpenRead(projektOrdner + csvDatei));
                while (!reader.EndOfStream)
                {
                    string[] inhalt = reader.ReadLine().Split(';');
                    for (int i = 0; i < inhalt.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                Program.ankunftszeit = inhalt[i].ToString();
                                break;
                            case 1:
                                Program.fahrtzeit = inhalt[i].ToString();
                                break;
                            case 2:
                                Program.fertigmachzeit = inhalt[i].ToString();
                                break;
                            case 3:
                                Program.weitereZeit = inhalt[i].ToString();
                                break;
                        }
                    }
                }
                reader.Close();
                reader.Dispose();
            }
        }

        public void Speichern()
        {
            File.WriteAllText(projektOrdner + csvDatei, string.Empty);
            string neuerInhalt = Program.ankunftszeit + ";" + Program.fahrtzeit + ";" + Program.fertigmachzeit + ";" + Program.weitereZeit;
            File.WriteAllText(projektOrdner + csvDatei, neuerInhalt);
        }
    }
}
