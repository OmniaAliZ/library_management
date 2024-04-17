public class Library
{
    public List<Book> Books;
    public List<User> Users;
    public INotificationService notificationService;
    public Library(INotificationService aNotificationService)
    {
        notificationService = aNotificationService;
        Books = new List<Book>();
        Users = new List<User>();
    }
    public void AddBook(Book newBook)
    {
        if (Books.Contains(newBook))
        {
            Console.WriteLine($"{newBook.BookTitle} Already exists.");
            notificationService.SendNotificationOnFailure(newBook);
        }
        else
        {
            Books.Add(newBook);
            Console.WriteLine($"{newBook.BookTitle} added.");
            notificationService.SendNotificationOnSucess();
        }
    }
    public void AddUser(User newUser)
    {
        if (Users.Contains(newUser))
        {
            Console.WriteLine($"{newUser.UserName} Already exists.");
            notificationService.SendNotificationOnFailure(newUser);
            //    notificationService.SendNotificationOnFailure($"{newUser} is not added");
        }
        else
        {
            Users.Add(newUser);
            Console.WriteLine($"{newUser.UserName} added.");
            notificationService.SendNotificationOnSucess(newUser);
        }
    }
    public string FindBook(string title)
    {
        Book? foundBook = Books.Find(book => book.BookTitle == title);
        return $"{foundBook}";
    }
    public string FindUser(string name)
    {
        User? foundUser = Users.Find(user => user.UserName == name);
        return $"{foundUser}";
    }
    public void DeleteBook(Guid id)
    {
        Book? foundBook = Books.Find(book => book.Id == id);
        if (foundBook is not null)
        {
            Books.Remove(foundBook);
            Console.WriteLine($"Hey, book with Id {id} deleted ");
            notificationService.SendNotificationOnSucess(foundBook);
        }
        else
        {
            Console.WriteLine("Book Not Found");
            notificationService.SendNotificationOnFailure();
        }
    }
    public void DeleteUser(Guid id)
    {
        User? foundUser = Users.Find(user => user.Id == id);
        if (foundUser is not null)
        {
            Users.Remove(foundUser);
            Console.WriteLine($"Hey, user with Id {id} deleted ");
            notificationService.SendNotificationOnSucess(foundUser);
        }
        else
        {
            Console.WriteLine("User Not Found");
            notificationService.SendNotificationOnFailure();
        }
    }
    public void GetBooks()
    {
        var sortedBooks = from book in Books
                          orderby book.Date
                          select book;
        foreach (var book in sortedBooks)
        {
            Console.WriteLine(book.ToString() + '\n');
        }
    }
    public void GetUsers()
    {
        var sortedUsers = from user in Users
                          orderby user.Date
                          select user;
        foreach (var user in Users)
        {
            Console.WriteLine(user.ToString() + '\n');
        }
    }
}
