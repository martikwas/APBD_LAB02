using Lab02;

public class Program
{
    
    static List<Kontenerowiec> kontenerowceLista = new List<Kontenerowiec>();
    static List<Kontener> konteneryLista = new List<Kontener>();
    
    
    public static void Main(string[] args)
    {
        MainMenu();
    }
    
      static void MainMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Lista kontenerowców:");
            if (kontenerowceLista.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                foreach (var statek in kontenerowceLista)
                {
                    Console.WriteLine(statek.idKontenerowiec);
                }
            }

            Console.WriteLine("\nLista kontenerów:");
            if (konteneryLista.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                foreach (var kontener in konteneryLista)
                {
                    Console.WriteLine(kontener.numerSeryjny);
                }
            }

            Console.WriteLine("\nMożliwe akcje:");
            Console.WriteLine("1. Dodaj kontenerowiec");
            Console.WriteLine("2. Dodaj konterner");
            Console.WriteLine("3. Exit");

            string opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    DodajKontenerowiec();
                    break;
                case "2":
                    DodajKontener();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór.");
                    break;
                    
            }
        }
    }
    
    static void DodajKontenerowiec()
    {
        Console.WriteLine("Podaj maksymalną prędkość statku (w węzłach): ");
        int maxPredkosc = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj maksymalną liczbę kontenerów na statku: ");
        int maxLiczbaKontenerow = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj maksymalną wagę kontenerów na statku (w tonach): ");
        int maxWagaKontenerow = int.Parse(Console.ReadLine());

        Kontenerowiec kontenerowiec = new Kontenerowiec(maxPredkosc, maxLiczbaKontenerow, maxWagaKontenerow);
        kontenerowceLista.Add(kontenerowiec);

        Console.WriteLine($"Kontenerowiec {kontenerowiec.idKontenerowiec} został dodany!");
        Console.ReadKey();
    }
    
    static void DodajKontener()
        {
            Console.WriteLine("Wybierz typ kontenera (1: Płyn, 2: Gaz, 3: Chłodniczy): ");
            int typKontenera = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj wysokość kontenera (w cm): ");
            int wysokosc = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj głębokość kontenera (w cm): ");
            int glebokoscKontenera = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj wagę kontenera (w kg): ");
            int wagaKontenera = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj maksymalną ładowność kontenera (w kg): ");
            int maxLadownosc = int.Parse(Console.ReadLine());

            Kontener nowyKontener = null;

            switch (typKontenera)
            {
                case 1:
                    Console.WriteLine("Czy kontener jest niebezpieczny? (true/false): ");
                    bool czyNiebezpieczny = bool.Parse(Console.ReadLine());
                    nowyKontener = new KontenerPlyny(wysokosc, glebokoscKontenera, wagaKontenera, maxLadownosc,
                        czyNiebezpieczny);
                    konteneryLista.Add(nowyKontener);
                    Console.WriteLine($"Kontener {Kontener.idKontener} został dodany!");
                    break;
                case 2:
                    Console.WriteLine("Podaj ciśnienie gazu (w atmosferach): ");
                    int cisnienie = int.Parse(Console.ReadLine());
                    nowyKontener = new KontenerGaz(wysokosc, glebokoscKontenera, wagaKontenera, maxLadownosc,
                        cisnienie);
                    konteneryLista.Add(nowyKontener);
                    Console.WriteLine($"Kontener {Kontener.idKontener} został dodany!");
                    break;
                case 3:
                    Console.WriteLine("Podaj typ produktu przechowywanego w kontenerze (banany, ryby, mięso): ");
                    string produkt = Console.ReadLine();
                    Console.WriteLine("Podaj temperaturę kontenera (w °C): ");
                    double temperatura = double.Parse(Console.ReadLine());
                    nowyKontener = new KontenerChlodniczy(wysokosc, glebokoscKontenera, wagaKontenera, maxLadownosc,
                        produkt, temperatura);
                    konteneryLista.Add(nowyKontener);
                    Console.WriteLine($"Kontener {Kontener.idKontener} został dodany!");
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór.");
                    return;
            }
        }

}