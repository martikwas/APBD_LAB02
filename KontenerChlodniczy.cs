namespace Lab02;

public class KontenerChlodniczy : Kontener, IHazardNotifier
{
    
    protected string rodzajProduktu {get; set;}
    protected double temperaturaKontenera {get; set;}

    private Dictionary<string, double> produktyItemperatury = new Dictionary<string, double>()
    {
        {"banany", 13.3},
        {"czekolada", 18},
        {"ryby", 2},
        {"mięso", -15},
        {"lody", -18},
        {"pizza mrożona", -30},
        {"kiełbaski", 5},
        {"masło", 20.5},
        {"jajka", 19}
    };
    
    public KontenerChlodniczy(int wysokosc, int glebokoscKontenera, int wagaKontenera, int maxLadownosc, string rodzajProduktu, double temperaturaKontenera) 
        : base(wysokosc, glebokoscKontenera, wagaKontenera, maxLadownosc)
    {
        this.rodzajProduktu = rodzajProduktu;
        this.temperaturaKontenera = temperaturaKontenera;

        
        if (!produktyItemperatury.ContainsKey(rodzajProduktu))
        {
            throw new ArgumentException($"Produkt '{rodzajProduktu}' nie jest obsługiwany przez kontener chłodniczy.");
        }

        if (temperaturaKontenera < produktyItemperatury[rodzajProduktu])
        {
            notify();
            throw new Exception($"Temperatura kontenera ({temperaturaKontenera}) jest za niska dla produktu '{rodzajProduktu}'. Minimalna temperatura: {produktyItemperatury[rodzajProduktu]}°C");
        }

        numerSeryjny = "KON-C-" + idKontener; ;
    }

    public void notify()
    {
        Console.WriteLine("Wykryto niebezpieczne zdarzenie w kontenerze: "+idKontener);    }
}