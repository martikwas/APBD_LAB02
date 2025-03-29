namespace Lab02;

public class KontenerGaz : Kontener, IHazardNotifier
{
    private IHazardNotifier _hazardNotifierImplementation;
    protected int cisnienie { get; set; }
    
    
    public KontenerGaz(int wysokosc, int glebokoscKontenera, int wagaKontenera, int maxLadownosc, int cisnienie) 
        : base(wysokosc, glebokoscKontenera, wagaKontenera, maxLadownosc)
    {
        this.cisnienie = cisnienie;
        numerSeryjny = "KON-G-"+idKontener;
    }

    public override void ZaladujKontener(int masaLadunku)
    {
        if (masaLadunku > maxLadownosc)
        {
            notify();
            throw new OverfillException($"Masa ładunku ({this.masaLadunku} kg) przekracza dozwoloną ładowność: {maxLadownosc} kg!");
        }
        this.masaLadunku = masaLadunku;
    }

    public override void OproznijLadunek()
    {
        masaLadunku = (int)(masaLadunku * 0.05);
    }

    public void notify()
    {
        Console.WriteLine("Wykryto niebezpieczną sytuację na kontenerze: "+idKontener);
    }

    public override string ToString()
    {
        return base.ToString() + $" numer seryjny: {numerSeryjny}, Ciśnienie : {cisnienie}";
    }
}