using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar : OkosEszkoz
    {
        private const string NyitasParancs = "NYITAS:";
        private const string ZarasParancs = "ZARAS";

        private string pinKod;

        public bool ZartE { get; private set; } = true;

        public OkosZar(string azonosito, string nev, string pinKod)
        : base(azonosito, nev)
        {
            this.pinKod = pinKod;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs == null)
            {
                return;
            }

            if (parancs.StartsWith(NyitasParancs))
            {
                string megadottPin = parancs.Substring(NyitasParancs.Length);
                if (megadottPin == this.pinKod)
                {
                    this.ZartE = false;
                    this.UtolsoFrissites = DateTime.Now;
                }
            }
            else if (parancs == ZarasParancs)
            {
                this.ZartE = true;
                this.UtolsoFrissites = DateTime.Now;
            }
        }

        public override string AllapotJelentes()
        {
            return this.ZartE ? "ZÁRVA" : "NYITVA";
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();
            this.pinKod = "0000";
            this.ZartE = true;
        }
    }
}