namespace Lab02;

public class Kontenerowiec : IHazardNotifier
{
    private static int idKontenerowiecCounter = 0;
    public string idKontenerowiec {get; set; }
    public List<Kontener> Kontenery { get; set; } = new List<Kontener>();
    public int maxPredkosc { get; set; }
    public int maxLiczbaKontenerow { get; set; }
    public int maxWagaKontenerow { get; set; }

    public Kontenerowiec(int maxPredkosc, int maxLiczbaKontenerow, int maxWagaKontenerow)
    {
        this.maxPredkosc = maxPredkosc;
        this.maxLiczbaKontenerow = maxLiczbaKontenerow;
        this.maxWagaKontenerow = maxWagaKontenerow;
        
        idKontenerowiecCounter++;
        idKontenerowiec = "STATEK-"+idKontenerowiecCounter;
    }

    public void DodajKontener(Kontener kontener)
    {

        int calkowitaWaga = 0;
        
        if (Kontenery.Count > maxLiczbaKontenerow)
        {
            notify();
        }

        foreach (var k in Kontenery)
        {
            calkowitaWaga += k.masaLadunku + k.wagaKontenera;
        }

        if (calkowitaWaga > maxWagaKontenerow)
        {
            new Exception("Przekroczono maksymalną wagę kontenerów");
        }
        
    }

    public void UsunKontener(string numerSeryjny)
    {
        for(int i = 0; i < Kontenery.Count; i++)
        {
            if (Kontenery[i].numerSeryjny == numerSeryjny)
            {
                Kontenery.RemoveAt(i);
                Console.WriteLine($"Kontener o numerze seryjnym {numerSeryjny} został usunięty.");
            }
            else
            {
                Console.WriteLine($"Nie ma kontenera o numerze seryjnym {numerSeryjny}");

            }
        }
    }
    
    

    public override string ToString()
    {
        return $"Nazwa kontenerowca: {idKontenerowiec}, max prędkość: {maxPredkosc}, max liczba przeworzonych kontenerów : {maxLiczbaKontenerow}," +
               $"max waga przeworzonych kontenerów: {maxWagaKontenerow}  ";
    }

    public void notify()
    {
        Console.WriteLine("Przekroczono maksymalną liczbę kontenerów na statku");    
    }
}