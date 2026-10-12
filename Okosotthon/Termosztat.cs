using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz
    {
        private const string HomersekletParancs = "BEALLIT_HOMERSEKLET:";

        public double JelenlegiHomerseklet { get; private set; } = 21.0;
        public double CelHomerseklet { get; private set; }

        public Termosztat(string azonosito, string nev, double celHomerseklet)
        : base(azonosito, nev)
        {
            this.CelHomerseklet = celHomerseklet;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs != null && parancs.StartsWith(HomersekletParancs))
            {
                string ertek = parancs.Substring(HomersekletParancs.Length);

                // InvariantCulture: a "24.5" pontos formátum magyar gépen is működjön
                if (double.TryParse(ertek, NumberStyles.Float, CultureInfo.InvariantCulture, out double ujHomerseklet))
                {
                    this.CelHomerseklet = ujHomerseklet;
                    this.UtolsoFrissites = DateTime.Now;
                }
            }
        }

        public override string AllapotJelentes()
        {
            return $"Jelenlegi hőmérséklet: {this.JelenlegiHomerseklet} °C, célhőmérséklet: {this.CelHomerseklet} °C";
        }

        protected override bool OnTesztFuttatasa()
        {
            return this.CelHomerseklet >= 5.0 && this.CelHomerseklet <= 35.0;
        }
    }
}