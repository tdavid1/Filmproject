using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmproject
{
    internal class Program
    {
        static List<Film>filmek = new List<Film>();
        static void Main(string[] args)
        {
            Fajbeolvasas("filmadatbazis.csv");
        }
        private static void f7()
        {
            
        }
        private static object leggyakoribmufaj()
        {
            var mufagyakorisag = new Dictionary<string, int>();
            foreach(var item in filmek)
            {
                foreach(var mufaj in item.Mufaj)
                {
                    if (mufagyakorisag.ContainsKey(mufaj))
                    {
                        mufagyakorisag.Add(mufaj, 1);
                    }
                    else
                    {
                        mufagyakorisag[mufaj] +=1;
                    }
                }
            }
            foreach(KeyValuePair<string,int> mufaj in mufagyakorisag)
            {
                Console.WriteLine($"{mufaj.Key} - {mufaj.Value}");
            }
            return "";
        }
        private static void f4()
        {
            string keresendo = Console.ReadLine();
            List<string> cimek = filmkeres(keresendo);
            foreach (string item in cimek)
            {
                Console.WriteLine(item);
            }
        }

        private static List<string> filmkeres(string keresendo)
        {
            List<string> list = new List<string>();
            foreach(var item in filmek)
            {
                if (item.Cim.Contains(keresendo))
                {
                    list.Add(item.Cim);
                }
            }

            return list;
        }

        private static void f3()
        {
            string cim = Console.ReadLine();
            Film film = filmkers(cim);
            if(film == null)
            {
                Console.WriteLine("A megadott film nem található");
            }
            else
            {
                Console.WriteLine($"A megadott film {film.Hosszu} perces");
            }
        }

        private static Film filmkers(string cim)
        {
            int i = 0;
            while (i<filmek.Count && filmek[i].Cim != cim)
            {
                i++;
            }
            if (i < filmek.Count)
            {
                return filmek[i];
            }
            else
            {
                return null;
            }
        }

        private static void f1()
        {
            Console.WriteLine($"1. A filmek átlagos hossza: {getalenghthossz()}perc");
        }
        private static void f2() 
        {
            Film leghoszabbfilm = getleghosszabbfilm();
            Console.WriteLine($"2. A leghosszabb film Címe:{leghoszabbfilm.Cim} Hossza:{leghoszabbfilm.Hosszu}");
        }

        private static Film getleghosszabbfilm()
        {
            Film leghosszabb = filmek[0];
            for (int i = 1; i < filmek.Count; i++)
            {
                if (filmek[i].Hosszu > leghosszabb.Hosszu)
                {
                    leghosszabb = filmek[i];
                }
            }
            return leghosszabb;
        }

        private static object getalenghthossz()
        {
            int oszhoz=0;
            foreach (var item in filmek)
            {
                oszhoz += item.Hosszu;

            }
            return oszhoz/filmek.Count;
        }

        private static void Fajbeolvasas(string file)
        {
            using(StreamReader r = new StreamReader(file))
            {
                r.ReadLine();
                while (r.EndOfStream)
                {
                    string sor = r.ReadLine();
                    Film film = new Film(sor);
                    filmek.Add(film);
                }
            }
        }
    }
}
