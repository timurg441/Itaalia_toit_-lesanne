using System;

// Peamenüü - kasutaja suhtlus programmiga
class MainPage_Classidega
{
    public static void Käivita()
    {
        bool tootab = true;

        while (tootab)
        {
            Console.WriteLine("\n===== PEAMENÜÜ =====");
            Console.WriteLine("1 - Laadi andmed failist");
            Console.WriteLine("2 - Kuva menüü");
            Console.WriteLine("3 - Lisa uus roog");
            Console.WriteLine("4 - Kustuta roog");
            Console.WriteLine("5 - Välju");
            Console.Write("Valik: ");

            char valik = char.Parse(Console.ReadLine());

            switch (valik)
            {
                case '1':
                    Italia_FunktsioonidClassidega.LaeAndmedFailist();
                    break;
                case '2':
                    Italia_FunktsioonidClassidega.KuvaMenuu();
                    break;
                case '3':
                    Italia_FunktsioonidClassidega.LisaUusRoog();
                    break;
                case '4':
                    Italia_FunktsioonidClassidega.KustutaRoog();
                    break;
                case '5':
                    tootab = false;
                    break;
                default:
                    Console.WriteLine("Vale valik, proovi uuesti.");
                    break;
            }
        }
    }
}
