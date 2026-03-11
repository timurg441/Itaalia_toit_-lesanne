using System;

class Program
{
    static void Main(string[] args)
    {
        // Loob faili kui seda pole
        Italia_FunktsioonidClassidega.LooNaidisfail();

        // Laeb kohe andmed faili
        Italia_FunktsioonidClassidega.LaeAndmedFailist();

        // Avab peamenüü
        MainPage_Classidega.Käivita();

        // Do-while - ootab Backspace't enne sulgemist
        Console.WriteLine("\n----- Vajuta Backspace väljumiseks -----");
        ConsoleKeyInfo klahv = new ConsoleKeyInfo();

        do
        {
            Console.WriteLine("Vajuta Backspace");
            klahv = Console.ReadKey();
        }
        while (klahv.Key != ConsoleKey.Backspace);

        Console.WriteLine("\nNägemist!");
    }
}
