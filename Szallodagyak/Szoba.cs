using System;
using System.Collections.Generic;
using System.Text;

namespace Szallodagyak
{
    internal class Szoba
    {
        private int ejszakaiAr;
        private int feroHely;
        private static int osszesRegisztraltSzoba = 0;

        public string Szobaszam { get; set; }
        public int Emelet { get; set; }
        public int EjszakaiAr
        {
            get => ejszakaiAr;
            set => ejszakaiAr = value < 0 ? 0 : value;
        }
        public int FeroHely
        {
            get => feroHely;
            set => feroHely = value < 1 ? 1 : value;
        }
        public static int OsszesRegisztraltSzoba
        {
            get => osszesRegisztraltSzoba;
        }

        public Szoba(string szobaszam, int emelet, int ejszakaiAr) : this (szobaszam, emelet, ejszakaiAr, 2)
        {
           
        }
        public Szoba(string szobaszam, int emelet, int ejszakaiAr, int ferohely)
        {
            Szobaszam = szobaszam;
            Emelet = emelet;
            EjszakaiAr = ejszakaiAr;
            FeroHely = ferohely;
            osszesRegisztraltSzoba++;
        }
        public override string ToString()
        {
            return $"{Szobaszam} Emelet : {Emelet}. | Férőhely : {FeroHely} fő. | Ár: {EjszakaiAr} Ft/éj";
        }

        public int FoglalasErteke(int ejszakakSzama)
        {
            return ejszakakSzama * EjszakaiAr;
        }
    }
}
