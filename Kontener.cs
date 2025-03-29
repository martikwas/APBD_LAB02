using System.Diagnostics;

namespace Lab02;

public abstract class Kontener
{
    public static int idKontener = 0;

    public int masaLadunku {get; set;}
    protected int wysokosc;
    public int wagaKontenera {get; set;}
    protected int glebokoscKontenera;
    protected int maxLadownosc;
    public string numerSeryjny  {get; set;}

    protected Kontener(int wysokosc, int glebokoscKontenera,int wagaKontenera, int maxLadownosc)
    {
        this.wysokosc = wysokosc;
        this.glebokoscKontenera = glebokoscKontenera;
        this.wagaKontenera = wagaKontenera;
        this.maxLadownosc = maxLadownosc;
        idKontener++;
    }

    public virtual void OproznijLadunek()
    {
        masaLadunku = 0;
    }

    public virtual void ZaladujKontener(int masaLadunku)
    {
        if (masaLadunku > maxLadownosc)
        {
            throw new OverfillException($"Masa ładunku ({this.masaLadunku} kg) większa niż pojemność kontenera {maxLadownosc} kg!");
        }
        else
        {
            this.masaLadunku = masaLadunku;
        }
    }

    public override string ToString()
    {
        return $"Numer seryjny: {numerSeryjny}, Wysokość: {wysokosc}cm, Głębokość: {glebokoscKontenera}cm, " +
               $"Max Ładowność: {maxLadownosc}kg, Obecna Masa Ładunku: {masaLadunku}kg";
    }



}