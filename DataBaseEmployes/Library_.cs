namespace Libra
{
    public interface IMedia
    {
        string Title { get; }
        string Creator { get; }
        DateTime ReleaseDate { get; }
        decimal Price { get; }
        string Description { get; }
    }

    public interface IBorrowable
    {
        bool IsAvailable { get; }
        void Borrow(string userId);
        void Return();
    }

    public interface IUser
    {
        string UserId { get; }
        string FirstName { get; }
        string LastName { get; }
    }

    public interface ILibraryItem : IMedia, IBorrowable
    {
    }

    public class Book : ILibraryItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public bool IsAvailable { get; private set; } = true;
        public string Borrower { get; private set; }

        public string Creator => Author;

        public void Borrow(string userId)
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                Borrower = userId;
            }
            else
            {
                Console.WriteLine("Book is already borrowed.");
            }
        }

        public void Return()
        {
            if (!IsAvailable)
            {
                IsAvailable = true;
                Borrower = null;
            }
            else
            {
                Console.WriteLine("Book is already available.");
            }
        }
    }

    public class User : IUser
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Library
    {
        private List<ILibraryItem> items;
        private List<IUser> users;

        public Library()
        {
            items = new List<ILibraryItem>();
            users = new List<IUser>();
        }

        public void AddItem(ILibraryItem item)
        {
            items.Add(item);
        }

        public void RemoveItem(ILibraryItem item)
        {
            items.Remove(item);
        }

        public void AddUser(IUser user)
        {
            users.Add(user);
        }

        public void RemoveUser(IUser user)
        {
            users.Remove(user);
        }

        public void DisplayLibraryItems()
        {
            Console.WriteLine("\nLibrary Items:");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Title} by {item.Creator}, Available: {item.IsAvailable}");
            }
        }

        public void DisplayUsers()
        {
            Console.WriteLine("\nLibrary Users:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.UserId}: {user.FirstName} {user.LastName}");
            }
        }
    }
}


