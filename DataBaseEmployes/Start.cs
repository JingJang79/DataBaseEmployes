using System;
using System.Collections.Generic;
using Employee; // Dodaj przestrzeń nazw, gdzie znajduje się klasa Employee
using Libra;
class Program
{
    static void Main(string[] args)
    {
        List<Zadanie> zadania = new List<Zadanie>()
        {
            new Zadanie("Zadanko1", 1, DateTime.Now.AddDays(1)),
            new Zadanie("Zadanko2", 2, DateTime.Now.AddDays(3)),
            new Zadanie("Zadanko3", 3, DateTime.Now.AddDays(2)),
            new Zadanie("Zadanko4", 1, DateTime.Now.AddDays(4)),
            new Zadanie("Zadanko5", 2, DateTime.Now.AddDays(5))
        };

        EmployeeDatabase employeeDatabase = new EmployeeDatabase(); // Dodaj inicjalizację bazy danych pracowników

        employeeDatabase.AddEmployee(1, "Jan", "Kowalski", "Szef");
        employeeDatabase.AddEmployee(2, "Krzysztof", "Walczak", "Wiceszef");
        employeeDatabase.AddEmployee(3, "Kazimierz", "Wegrzyn", "Kadry");
        employeeDatabase.AddEmployee(4, "Wojciech", "Lotek", "Place");
        employeeDatabase.AddEmployee(5, "Katarzyna", "Zuk", "Finanse");
        employeeDatabase.AddEmployee(11, "Janusz", "Polak", "Handlowiec");
        employeeDatabase.AddEmployee(12, "Krzysztof", "Malik", "Handlowiec");
        employeeDatabase.AddEmployee(13, "Kazik", "Wistek", "Handlowiec");
        employeeDatabase.AddEmployee(14, "Maja", "Butek", "Handlowiec");
        employeeDatabase.AddEmployee(15, "Kris", "Zak", "Handlowiec");


        ZarządzanieZadaniami zarządzanie = new ZarządzanieZadaniami();
        List<Zadanie> wynik = zarządzanie.FiltrujZadania(zadania, zadanie => zadanie.Priorytet >= 1);
        Console.WriteLine("Zadania o priorytecie większym lub równym 1:");
        foreach (var zadanie in wynik)
        {
            Console.WriteLine(zadanie.Tytuł);
        }

        List<Zadanie> wynik1 = zarządzanie.FiltrujZadania(zadania, zadanie => zadanie.Termin > DateTime.Now);
        Console.WriteLine("\nZadania z terminem wykonania późniejszym niż dzisiaj:");
        foreach (var zadanie in wynik1)
        {
            Console.WriteLine(zadanie.Tytuł);
        }


        
        List<Employee.Employee> employees = employeeDatabase.GetEmployee();
        Console.WriteLine("\nLista pracowników:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"ID: {employee.Id}, Imię: {employee.FirstName}, Nazwisko: {employee.LastName}, Stanowisko: {employee.Position}");
        }

        // Tworzenie instancji biblioteki
        Library library = new Library();

        // Dodawanie użytkowników do biblioteki
        IUser user1 = new User { UserId = "1", FirstName = "John", LastName = "Doe" };
        IUser user2 = new User { UserId = "2", FirstName = "Jane", LastName = "Smith" };
        library.AddUser(user1);
        library.AddUser(user2);

        // Dodawanie książek do biblioteki
        ILibraryItem book1 = new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ReleaseDate = new DateTime(1925, 4, 10), Price = 15.99m, Description = "Classic novel" };
        ILibraryItem book2 = new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", ReleaseDate = new DateTime(1960, 7, 11), Price = 12.99m, Description = "Pulitzer Prize-winning novel" };
        library.AddItem(book1);
        library.AddItem(book2);

        // Wyświetlanie dostępnych książek
        library.DisplayLibraryItems();

        // Wypożyczanie książki
        if (book1 is IBorrowable borrowableBook)
        {
            borrowableBook.Borrow(user1.UserId);
        }

        // Wyświetlanie dostępności po wypożyczeniu
        library.DisplayLibraryItems();

        // Zwracanie książki
        if (book1 is IBorrowable returnableBook)
        {
            returnableBook.Return();
        }

        // Wyświetlanie dostępności po zwrocie
        library.DisplayLibraryItems();

        // Wyświetlanie użytkowników
        library.DisplayUsers();

        Console.ReadLine();
    }
}