using Szallodagyak;

List<Szoba> szobak = new List<Szoba>();
if (File.Exists("Szobak.txt"))
{
    foreach ( string aktsor in File.ReadAllLines("szobak.txt"))
    {
        string[] adatok = aktsor.Split(';');
        int db = adatok.Count();
        if (db != 4) continue;

        if (int.TryParse(adatok[1], out int emelet) && int.TryParse(adatok[2], out int ar) && int.TryParse(adatok[3], out int ferohely))
        {
            if (!string.IsNullOrWhiteSpace(adatok[0]))
            {
                Szoba aktualis = new Szoba(adatok[0], emelet, ar, ferohely);
                szobak.Add(aktualis);
            }
            else Console.WriteLine($"Hiányos adat(ok) a következő sorban: {aktsor}");
        }
        else Console.WriteLine($"Hiánzó számadat(ok) a következő sorban: {aktsor}");
    }
}
else Console.WriteLine("A szobak.txt fál nem létezik");

foreach ( Szoba szoba in szobak)
{
    Console.WriteLine(szoba);
}

Console.WriteLine($"Összes regisztrált szoba: {Szoba.OsszesRegisztraltSzoba}");
double osszes = 0;
foreach (Szoba szoba in szobak)
{
    osszes += szoba.EjszakaiAr * szoba.FeroHely;
}
Console.WriteLine($"Összesen {IlletekKalklator.VegosszegIFAVal(osszes)} FT bevétele van a szállodánakegy teli éjszaka alatt");

Szoba legnagy = szobak[0];
foreach(Szoba sz in szobak)
{
    if ( sz.FeroHely > legnagy.FeroHely)
    {
        legnagy = sz;
    }
}
Console.WriteLine($"A legnagyobb szoba: {legnagy}");

Szoba legnagy2 = szobak.MaxBy(sz => sz.FeroHely);
Console.WriteLine($"A legnagyobb szoba: {legnagy2}");