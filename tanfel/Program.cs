namespace tanfel
{
    class Tanfel
    {
        public string Tanar { get; set; }
        public string Tantargy { get; set; }
        public string Osztaly { get; set; }
        public int HetiOraszam { get; set; }

    }
    class Program
    {
        static List<Tanfel> felosztas = new List<Tanfel>();
        static void Main(string[] args)
        {
            //1. feladat
            Beolvas();

            //2. feladat
            Feladat2();

            //3. feladat
            Feladat3();

            //4. feladat
            Feladat4();

            //5. feladat//"of.txt"
            Feladat5();

            //6. feladat
            Feladat6();

            //7. feladat
            Feladat7();

            Console.ReadLine();
        }

        private static void Beolvas()
        {
            string[] adatok = File.ReadAllLines(@"beosztas.txt");

            for (int i = 0; i < adatok.Length; i += 4)
            {
                Tanfel tanar = new Tanfel();
                tanar.Tanar = adatok[i];
                tanar.Tantargy = adatok[i + 1];
                tanar.Osztaly = adatok[i + 2];
                tanar.HetiOraszam = int.Parse(adatok[i + 3]);
                felosztas.Add(tanar);
            }
        }
        private static void Feladat2()
        {
            Console.WriteLine("2. feladat");
            Console.WriteLine("Az állományban {0} bejegyzés van.", felosztas.Count);
        }
        private static void Feladat3()
        {
            Console.WriteLine("3. feladat");
            Console.WriteLine("Az iskolában a heti összóraszám: {0}", felosztas.Sum(x => x.HetiOraszam));
        }
        private static void Feladat4()
        {
            Console.WriteLine("4. feladat");
            Console.Write("Egy tanár neve= ");

            string nev = Console.ReadLine();
            var hetiOsszes = felosztas.Where(x => x.Tanar.Equals(nev)).ToList();

            Console.WriteLine("A tanár heti óraszáma: {0}", hetiOsszes.Sum(x => x.HetiOraszam));

        }
        private static void Feladat5()
        {
            var osztalyfonokok = felosztas.Where(x => x.Tantargy.Equals("osztalyfonoki")).ToList();
            StreamWriter sw = new StreamWriter(@"of.txt");

            foreach (var item in osztalyfonokok)
            {
                sw.WriteLine($"{item.Osztaly} - {item.Tanar}");
            }

            sw.Close();
        }
        private static void Feladat6()
        {
            Console.WriteLine("6. feladat");

            Console.Write("Osztály= ");
            string bOsztaly = Console.ReadLine();
            Console.Write("Tantárgy= ");
            string bTantargy = Console.ReadLine();

            string[] valasz = { "Csoportbontásban tanulják.", "Osztályszinten tanulják." };

            var szures = felosztas.Where(x => x.Osztaly.Equals(bOsztaly) && x.Tantargy.Equals(bTantargy));

            if(szures.Count() >= 2)
            {
                Console.WriteLine(valasz[0]);
            }
            else Console.WriteLine(valasz[1]);

        }
        private static void Feladat7()
        {
            Console.WriteLine("7. feladat");

            var tanarok = felosztas.GroupBy(x => x.Tanar).ToList();
            Console.WriteLine("Az iskolában {0} tanár tanít.", tanarok.Count);
        }
    }
}