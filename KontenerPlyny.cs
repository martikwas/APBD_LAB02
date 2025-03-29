namespace Lab02;

public class KontenerPlyny : Kontener, IHazardNotifier
{
    protected bool czyNiebezpieczny { get; set; }

    public KontenerPlyny(int wysokosc, int glebokoscKontenera, int wagaKontenera, int maxLadownosc, bool czyNiebezpieczny) 
        : base(wysokosc, glebokoscKontenera, wagaKontenera, maxLadownosc)
    { 
        this.czyNiebezpieczny = czyNiebezpieczny;
        numerSeryjny = "KON-L-"+idKontener;
    }

    public override void ZaladujKontener(int masaLadunku)
    {
        
        int limitladownosc = czyNiebezpieczny ? (int)(maxLadownosc * 0.5) : (int)(maxLadownosc * 0.9);
        
        if (masaLadunku > limitladownosc)
        {
            notify();
            throw new OverfillException($"Masa ładunku ({this.masaLadunku} kg) przekracza dozwolony limit: {limitladownosc} kg!");
        }

        this.masaLadunku = masaLadunku;
    }

    public override string ToString()
    {
        return base.ToString() + $" numer seryjny: {numerSeryjny} czy niebezpieczny: {czyNiebezpieczny}";
    }

    public void notify()
    {
        Console.WriteLine("Wykryto niebezpieczną sytuację na kontenerze: "+idKontener);
    }
}