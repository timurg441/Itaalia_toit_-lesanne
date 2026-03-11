using System;
using System.Collections.Generic;

// Klass, mis kirjeldab üht rooga menüüs
class Menuu
{
    public string Nimi { get; set; }
    public string Koostisosad { get; set; }
    public double Hind { get; set; }

    public Menuu(string nimi, string koostisosad, double hind)
    {
        Nimi = nimi;
        Koostisosad = koostisosad;
        Hind = hind;
    }

    // Muudab objekti tekstireaks faili salvestamiseks
    public string FailireaksTeisendus()
    {
        return $"{Nimi};{Koostisosad};{Hind}";
    }
}
