using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analiza_teksta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tekst;
            Console.WriteLine("Unesi tekst:");
            tekst = Console.ReadLine();
            UkupanBrojZnakova(tekst);
            BrojRijeci(tekst);
            Brojrecenica(tekst);
            PojavljivanjeNajdulja(tekst);
            BrojSamogSug(tekst);
            ProsjecnaDuljina(tekst);
            Console.ReadKey();
        }
        static void UkupanBrojZnakova(string input)
        {
            char[] znakovi = input.ToCharArray();
            int broj = znakovi.Length;
            Console.WriteLine("Ukupan broj znakova: {0} ", broj);
        }
        static void BrojRijeci(string input)
        {
            string[] rijeci = input.Split(' ');
            Console.WriteLine($"Broj riječi: {rijeci.Length}");
        }
        static void Brojrecenica(string input)
        {
            int brojac = 0;
            char[] znakovi = input.ToCharArray();
            foreach (char c in znakovi)
            {
                if (c == '.' || c == '?' || c == '!')
                    brojac++;
            }
            Console.WriteLine($"Broj rečenica: {brojac}");
        }

        static void PojavljivanjeNajdulja(string input)
        {
            // Razbijanje rečenice na riječi
            string[] words = input.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            // Inicijalizacija rječnika za pohranu broja ponavljanja svake riječi
            Dictionary<string, int> sverijeci = new Dictionary<string, int>();

            // Brojanje ponavljanja svake riječi
            foreach (string word in words)
            {
                string rijec = OcistiRijec(word);
                if (sverijeci.ContainsKey(rijec))
                {
                    sverijeci[rijec]++;
                }
                else
                {
                    sverijeci[rijec] = 1;
                }
            }

            foreach (var par in sverijeci)
            {
                Console.WriteLine($"{par.Key}: {par.Value}");
            }
            string najcescarijec = "";
            int brojac = 0;
            foreach (var pair in sverijeci)
            {
                if (pair.Value > brojac)
                {
                    najcescarijec = pair.Key;
                    brojac = pair.Value;
                }
            }
            Console.WriteLine($"Najčešća riječ u tekstu: {najcescarijec}");
            Console.WriteLine($"Duljina najčešće riječi: {najcescarijec.Length}");

        }

        static string OcistiRijec(string rijec)
        {
            // Uklanjanje suvišnih znakova interpunkcije i pretvaranje u mala slova
            return rijec.Trim().ToLower();
        }

        static void BrojSamogSug(string input)

        {
            string c1;
            char[] recenica = input.ToCharArray();
            int samoglasnici = 0;
            int suglasnici = 0;
            foreach (char c in recenica)
            {
                c1 = c.ToString().ToLower();
                if ((c1 == "a"|| c1 == "e" || c1 == "i" || c1 == "o" || c1 == "u"))
                {
                    samoglasnici++;
                }
                else if(c!=' ' && c!= '.' && c!= ',' && c!= '?'&& c!= '!'&& c!= ':') 
                { 
                suglasnici++;
                }
            }
            Console.WriteLine($"Broj samoglasnika: {samoglasnici}");
            Console.WriteLine($"Broj suglasnika: {suglasnici}");


        }
        static void ProsjecnaDuljina(string input)
        {
            string rijec;
            double duljina = 0;
            string[] rijeci = input.Split(' ');
            for (int i = 0; i< rijeci.Length; i++)
            {
                rijec = OcistiRijec(rijeci[i]);
                duljina += rijec.Length;

            }
            double prosjecna = duljina / rijeci.Count();
            prosjecna = Math.Round(prosjecna, 2);
            Console.WriteLine($"Prosječna duljina riječi je: {prosjecna}");
        }
    }


}

