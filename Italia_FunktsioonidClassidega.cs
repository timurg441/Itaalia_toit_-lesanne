using System;
using System.Collections.Generic;
using System.IO;

// Klass kõigi restorani funktsioonidega
class Italia_FunktsioonidClassidega
{
    static string failiTee = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Menuu.txt");

    // Tuple-põhine nimekiri - nagu ülesandes nõutud
    static List<Tuple<string, string, double>> toiduNimekiri = new List<Tuple<string, string, double>>();

    // Loob näidisfaili kui seda pole
    public static void LooNaidisfail()
    {
        if (!File.Exists(failiTee))
        {
            string[] read = {
                "Margherita pitsa;San Marzano tomatid, värske mozzarella, basiilik;8.50",
                "Pasta Carbonara;Spagetid, guanciale, pecorino juust, muna;12.00",
                "Tiramisu;Mascarpone, espresso, savoiardi küpsised;6.50"
            };
            File.WriteAllLines(failiTee, read);
            Console.WriteLine("Menuu.txt loodud näidisandmetega.");
        }
    }

    // Loeb andmed failist ja täidab tuple-nimekirja
    public static void LaeAndmedFailist()
    {
        toiduNimekiri.Clear();
        Console.WriteLine("Laetakse andmed failist...");

        if (!File.Exists(failiTee))
        {
            Console.WriteLine("Faili ei leitud!");
            return;
        }

        string[] read = File.ReadAllLines(failiTee);

        foreach (string rida in read)
        {
            string[] osad = rida.Split(';');

            if (osad.Length == 3)
            {
                string nimi    = osad[0];
                string koostis = osad[1];
                double hind    = double.Parse(osad[2].Replace('.', ','));

                toiduNimekiri.Add(Tuple.Create(nimi, koostis, hind));
            }
        }

        Console.WriteLine($"Laaditud {toiduNimekiri.Count} rooga.");
    }

    // Kuvab menüü ilusalt joondatuna
    public static void KuvaMenuu()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔══════════════════════════════════════════════╗");
        Console.WriteLine("║       🍕  ITAALIA RESTORAN - MENÜÜ  🍕       ║");
        Console.WriteLine("╚══════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();

        if (toiduNimekiri.Count == 0)
        {
            Console.WriteLine("  Menüü on tühi. Laadige esmalt andmed (valik 1).");
            return;
        }

        int nr = 1;
        foreach (Tuple<string, string, double> toit in toiduNimekiri)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  {nr}. {toit.Item1.PadRight(28)} {toit.Item3:F2} €");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"     Koostis: {toit.Item2}");
            Console.ResetColor();

            Console.WriteLine("  ──────────────────────────────────────────");
            nr++;
        }

        Console.WriteLine();
    }

    // Lisab uue roa käsitsi ja salvestab faili
    public static void LisaUusRoog()
    {
        Console.Write("Roa nimi: ");
        string nimi = Console.ReadLine();

        Console.Write("Koostisosad: ");
        string koostis = Console.ReadLine();

        Console.Write("Hind (nt 9.90): ");
        double hind = double.Parse(Console.ReadLine().Replace('.', ','));

        toiduNimekiri.Add(Tuple.Create(nimi, koostis, hind));
        SalvestaFaili();

        Console.WriteLine($"Roog '{nimi}' lisatud!");
    }

    // Kustutab roa nime järgi
    public static void KustutaRoog()
    {
        Console.Write("Sisesta kustutatava roa nimi: ");
        string otsitav = Console.ReadLine();

        int indeks = toiduNimekiri.FindIndex(t => t.Item1.Equals(otsitav, StringComparison.OrdinalIgnoreCase));

        if (indeks >= 0)
        {
            toiduNimekiri.RemoveAt(indeks);
            SalvestaFaili();
            Console.WriteLine($"Roog '{otsitav}' kustutatud.");
        }
        else
        {
            Console.WriteLine($"Rooga '{otsitav}' ei leitud.");
        }
    }

    // Salvestab nimekirja tagasi faili
    static void SalvestaFaili()
    {
        List<string> read = new List<string>();
        foreach (Tuple<string, string, double> toit in toiduNimekiri)
        {
            read.Add($"{toit.Item1};{toit.Item2};{toit.Item3}");
        }
        File.WriteAllLines(failiTee, read);
    }
}
