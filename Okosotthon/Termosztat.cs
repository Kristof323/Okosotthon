using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz, IIdozitheto, IStatisztika
    {
        public double JelenlegiHomerseklet { get; private set; }
        public double CelHomerseklet { get; private set; }
        private int _hatralevoIdo;

        public Termosztat(string azonosito, string nev, double celHomerseklet)
        : base(azonosito, nev)
        {
            this.CelHomerseklet = celHomerseklet;
            this.JelenlegiHomerseklet = 21.0;
        }

        public void IdozitestBeallit(int perc)
        {
            _hatralevoIdo = perc;
        }

        public int GetMaradtIdo()
        {
            return _hatralevoIdo;
        }

        public string StatisztikatKeszit()
        {
            return $"Termosztát statisztika: Jelenlegi {JelenlegiHomerseklet}°C, Cél: {CelHomerseklet}°C";
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("BEALLIT_HOMERSEKLET:"))
            {
                string[] parts = parancs.Split(":");
                if (parts.Length == 2 && double.TryParse(parts[1], out double ujCelHomerseklet))
                {
                    this.CelHomerseklet = ujCelHomerseklet;
                }
            }
        }

        public override string AllapotJelentes()
        {
            return $"Jelenlegi hőmérséklet: {JelenlegiHomerseklet} °C, célhőmérséklet: {CelHomerseklet} °C";
        }

        protected override bool OnTesztFuttatasa()
        {
            return this.CelHomerseklet >= 5.0 && this.CelHomerseklet <= 35.0;
        }

    }
}
