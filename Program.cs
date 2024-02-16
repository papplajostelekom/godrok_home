using System.ComponentModel.DataAnnotations;

namespace godrok_home
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.
            List<int> godrok_list = new List<int>();
            StreamReader sr = File.OpenText("melyseg.txt");
            while (!sr.EndOfStream) godrok_list.Add(int.Parse(sr.ReadLine()));
            sr.Close();
            int n = godrok_list.Count;
            Console.WriteLine($"1. feladat\nA fájl adatainak száma: {n}\n");
            //2.
            Console.Write($"2. feladat\nAdjon meg egy távolságértéket: ");
            int tavolsag = int.Parse(Console.ReadLine());

            if (godrok_list[tavolsag] == 0) Console.WriteLine("Az adott helyen nincs gödör.");
            else Console.WriteLine($"Ezen a helyen a felszín {godrok_list[tavolsag]} m mélyen van.\n");

            //3.
            double erintetlen_szamol = 0;
            foreach (var i in godrok_list) if (i == 0) erintetlen_szamol++;
            Console.WriteLine($"3. feladat");
            Console.WriteLine($"Az érintetlen terület aránya: {erintetlen_szamol / n:p2}");
            StreamWriter sw = new StreamWriter("godrok.txt");    
            int godrok_szama = 0; int szamol_O = 0;
            for (int i = 0; i < n; i++)
            {
                if (godrok_list[i] == 0)
                {
                    szamol_O++;
                }
                else
                {
                    //Console.Write(godrok_list[i]);
                    sw.Write(godrok_list[i]);
                    if (godrok_list[i + 1] == 0)
                    {
                        //Console.WriteLine();
                        sw.WriteLine();
                        godrok_szama++;
                    }
                }
            }
            sw.Close();
            Console.WriteLine("\n5. feladat");
            Console.WriteLine($"A gödrök száma: {godrok_szama}\n");
            int e = tavolsag;
            int v = tavolsag;
            if (godrok_list[tavolsag] > 0)
            {
                while (godrok_list[v] != 0) v++;
                while (godrok_list[e] != 0) e--;
                Console.WriteLine("6.feladat\na)");
                Console.WriteLine($"A gödör kezdete: {e+2} méter, a gödör vége: {v} méter.");
                int max = 0;
                for (int i = e; i < v; i++)
                {
                    if (godrok_list[max] < godrok_list[i]) max = i;
                }
                Console.WriteLine($"A gödör legmélyebb pontja: {max}-ik méternél {godrok_list[max]} méter.");
                Console.WriteLine("b)");
                bool emelkedik_e = false, emelkedik_h = false;
                for (int i = max; i < v; i++)
                {
                    if (godrok_list[i] < godrok_list[i + 1])
                    {
                        emelkedik_e=true;
                    }
                }
                for (int i = e; i < max; i++)
                {
                    if (godrok_list[i] < godrok_list[i + 1])
                    { 
                    emelkedik_h=true;
                    }
                }
                if(emelkedik_h && emelkedik_e) Console.WriteLine("Nem mélyül folyamatosan.");
                Console.WriteLine("c)");
                Console.WriteLine($"A legnagyobb mélysége {godrok_list[max]} méter");
                int terf_sum = 0;
                for (int i = e; i < v; i++)
                {
                    terf_sum += godrok_list[i];
                }
                Console.WriteLine($"d)\nA térfogata: {terf_sum * 10} m^3.");
                int viz_terf = 0;
                for (int i = e; i < v; i++)
                {
                    if (godrok_list[i]>2)
                    { 
                        viz_terf += godrok_list[i];
                    }
                }
                Console.WriteLine($"e)\nA vízmennyiség {viz_terf*10} m ^3.");
            }
        }
    }
}
