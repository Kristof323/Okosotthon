using System;

namespace Okosotthon
{
    public class OkosKozpontiRiaszto : OkosEszkoz, IIdozitheto, IHangjelzo, IStatisztika
    {
        private int _hatralevoIdo;
        private int _hangjelzesekSzama;

        public OkosKozpontiRiaszto(string azonosito, string nev) : base(azonosito, nev) { }

        public void IdozitestBeallit(int perc) => _hatralevoIdo = perc;
        public int GetMaradtIdo() => _hatralevoIdo;

        public void Csipog(int hosszu)
        {
            _hangjelzesekSzama++;
            Console.WriteLine($"Riasztó csipog: {hosszu} ms");
        }

        public void VeszjelzesInditasa()
        {
            Console.WriteLine("Riasztó VÉSZJELZÉS!");
        }

        public string StatisztikatKeszit() => $"Riasztó statisztika: Összes hangjelzés: {_hangjelzesekSzama}";

        public override void ParancsVegrehajtasa(string parancs) { }
        public override string AllapotJelentes() => "Riasztó aktív";
        protected override bool OnTesztFuttatasa() => true;
    }
}
