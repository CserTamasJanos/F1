using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LegjobbJatekok
{
    internal class Program
    {
        static List<Jatek> jatekok = new List<Jatek>();
        static void Main(string[] args)
        {
            DataLoad();

            Feladat3();

            Feladat4();

            Feladat5();

            Feladat6();

            Feladat7();

            Feladat8();

            Console.WriteLine("9. Feladat: Adjon meg egy platform típust:");
            string tipus = Console.ReadLine();
            Feladat9(tipus);

            Feladat10();

            Console.ReadKey();
        }

        static void DataLoad()
        {
            using (StreamReader sr = new StreamReader("games.txt"))
            {
                string actual_line = string.Empty;
                while((actual_line = sr.ReadLine()) != null)
                {
                    string[] split = actual_line.Split(';');

                    jatekok.Add(new Jatek(Convert.ToInt32(split[0]), split[1], split[2], split[3], split[4].Trim()));

                }
            }
        }

        static void Feladat3()
        {
            Console.WriteLine($"Feladat 3: \n \t Összesn {jatekok.Count} db játék szerepel a listában.");
        }

        static void Feladat4()
        {
            var jateknevek = jatekok.Where(x => x.Platform == "PC").ToList();

            Console.WriteLine($"4. Feladat: \n \t {jateknevek.Count()} db játeék jelent meg PC-re.");
        }

        static void Feladat5()
        {
            var year = jatekok.GroupBy(t => new { t.KiadasiIdo }).Select(grp => grp.First());

            string years = string.Empty;

            foreach(var m in year)
            {
                if(jatekok.Where(x=> x.KiadasiIdo == m.KiadasiIdo).Count() >= 7)
                {
                    if(string.IsNullOrEmpty(years))
                    {
                        years += m.KiadasiIdo;
                    }
                    else
                    {
                        years += " " + m.KiadasiIdo;
                    }
                }
            }

            Console.WriteLine($"5. Feladat: \n \t Igazán sikeres évek: \n {years}");
        }

        static void Feladat6()
        {
            List<Jatek> NESes = jatekok.Where(x => x.Platform == "NES").ToList();

            int t = 0;
            string n = string.Empty;
            foreach(Jatek j in NESes)
            {
                if(j.KiadasiIdo > t)
                {
                    t = j.KiadasiIdo;
                    n = j.Nev;
                }
            }

            Console.WriteLine($"6. Feladat: \n  \t A legutolsó NEs jaáték a: {n}, megjelent: {t}");

        }

        static void Feladat7()
        {
            var z = jatekok.GroupBy(x=> x.Keszito).Select(x => new { Jatekszam = x.Count(), Nev = x.Key }).ToList();

            int sz = 0;
            string n = string.Empty;
            foreach(var zz in z)
            {
                if(zz.Jatekszam > sz)
                {
                    sz = zz.Jatekszam;
                    n = zz.Nev;
                }
            }

            Console.WriteLine($"7. Feladat:\n \t A legtöbb játékot, {sz}-et, a {n} kiadó adta ki.");
        }

        static void Feladat8()
        {
            var nevek = jatekok.GroupBy(x => x.Tipus).Select(x => x.First()).OrderBy(v=> v.Tipus).ToList();

            using (StreamWriter sw = new StreamWriter("genre.txt"))
            {
                foreach (var n in nevek)
                {
                    sw.WriteLine(n.Tipus);
                }
            }
        }

        static void Feladat9(string type)
        {
            if(jatekok.FirstOrDefault(x=> x.Platform == type) != null)
            {
                var szurt = jatekok.Where(c => c.Platform == type).ToList();

                int kiirando = szurt.Count() >= 10 ? 10 : szurt.Count(); 
                //kell még ide random
                for(int i = 0; i < kiirando; i++)
                {
                    Console.WriteLine(szurt[i].Nev);
                }
            }
        }

        static void Feladat10()
        {
            int pcCount = jatekok.Where(x => x.Platform == "PC" && x.Keszito == "Electronic Arts").Count();
            int allEL = jatekok.Where(x => x.Keszito == "Electronic Arts").Count();

            Console.WriteLine($"10. Feladat: \n \t Az electronic Arts játékainak {((float)pcCount/(float)allEL)*100} %-a PC-s játék.");
        }
    }
}
