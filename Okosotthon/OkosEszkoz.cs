using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public abstract class OkosEszkoz
    {
        private string azonosito = string.Empty;
        private string nev = string.Empty;
        private bool onlineE;
        private DateTime utolsoFrissites;

        public string Azonosito
        {
            get { return this.azonosito; }
            private set { this.azonosito = value; }
        }

        public string Nev
        {
            get { return this.nev; }
            private set { this.nev = value; }
        }

        public bool OnlineE
        {
            get { return this.onlineE; }
            private set { this.onlineE = value; }
        }

        public DateTime UtolsoFrissites
        {
            get { return this.utolsoFrissites; }
            protected set { this.utolsoFrissites = value; }
        }

        public OkosEszkoz(string azonosito, string nev)
        {
            this.Azonosito = azonosito;
            this.Nev = nev;
            this.OnlineE = false;
            this.UtolsoFrissites = DateTime.Now;
        }

        public void Csatlakozas()
        {
            this.OnlineE = true;
            this.UtolsoFrissites = DateTime.Now;
        }

        public void KapcsolatBontasa()
        {
            this.OnlineE = false;
            this.UtolsoFrissites = DateTime.Now;
        }

        // Sablonfüggvény (Template Method)
        public bool DiagnosztikaFuttatasa()
        {
            if (!this.OnlineE)
            {
                return false;
            }

            bool eredmeny = this.OnTesztFuttatasa();
            return eredmeny;
        }

        public virtual void GyariBeallitasokVisszaallitasa()
        {
            // Alapértelmezett beállítások: frissítési idő újraállítása
            this.UtolsoFrissites = DateTime.Now;
        }

        public abstract void ParancsVegrehajtasa(string parancs);
        public abstract string AllapotJelentes();
        protected abstract bool OnTesztFuttatasa();
    }
}