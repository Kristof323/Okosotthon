using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar: OkosEszkoz, IHangjelzo, IStatisztika
    {
        private string pinKod;
        public bool ZartE { get; private set; }
        private int _sikertelenNyitasok;

        public OkosZar(string azonosito, string nev, string pinKod)
        : base(azonosito, nev)
        {
            this.pinKod = pinKod;
            this.ZartE = true;
        }

        public void Csipog(int hosszu)
        {
            Console.WriteLine($"Csipogás: {hosszu} ms");
        }

        public void VeszjelzesInditasa()
        {
            Console.WriteLine("VÉSZJELZÉS INDÍTVA!");
        }

        public string StatisztikatKeszit()
        {
            return $"OkosZár statisztika: Sikertelen nyitási kísérletek: {_sikertelenNyitasok}";
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("NYITAS:"))
            {
                string[] parts = parancs.Split(":");
                if (parts.Length == 2)
                {
                    string megadottPinKod = parts[1];
                    if (megadottPinKod == this.pinKod)
                    {
                        this.ZartE = false;
                    }
                    else
                    {
                        _sikertelenNyitasok++;
                        Csipog(500);
                        if (_sikertelenNyitasok >= 3)
                        {
                            VeszjelzesInditasa();
                        }
                    }
                }
            }
            else if (parancs == "ZARAS")
            {
                this.ZartE = true;
            }
        }


        public override string AllapotJelentes()
        {
            return ZartE ? "ZÁRVA" : "NYITVA";
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
