public class Zadanie
{
    public string Tytuł { get; set; }
    public int Priorytet { get; set; }
    public DateTime Termin { get; set; }

    public Zadanie(string tytuł, int priorytet, DateTime termin)
    {
        Tytuł = tytuł;
        Priorytet = priorytet;
        Termin = termin;
    }
}

public class ZarządzanieZadaniami
{
    public List<Zadanie> FiltrujZadania(List<Zadanie> zadania, Func<Zadanie, bool> kryterium)
    {
        List<Zadanie> filter = new List<Zadanie>();
        foreach (var zadanie in zadania)
        {
            if (kryterium(zadanie))
            {
                filter.Add(zadanie);
            }
        }
        return filter;
    }
}