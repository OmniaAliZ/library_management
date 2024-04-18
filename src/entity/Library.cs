public class Library
{
    public List<Book> Books;
    public List<User> Users;
    public INotificationService NotificationService;

    public Library(INotificationService notificationService)
    {
        NotificationService = notificationService;
        Books = new List<Book>();
        Users = new List<User>();
    }

    public void AddBook(Book newBook)
    {
        if (Books.Contains(newBook))
        {
            Console.WriteLine($"{newBook.BookTitle} Already exists.");
            NotificationService.SendNotificationOnFailure($"We encountered an issue adding {newBook.BookTitle}");
        }
        else
        {
            Books.Add(newBook);
            Console.WriteLine($"{newBook.BookTitle} added.");
            NotificationService.SendNotificationOnSuccess($"Hello, a new book: {newBook.BookTitle} has been successfully added to the Library");
        }
    }

    public void AddUser(User newUser)
    {
        if (Users.Contains(newUser))
        {
            Console.WriteLine($"{newUser.UserName} Already exists.");
            NotificationService.SendNotificationOnFailure($"We encountered an issue adding {newUser.UserName}");
        }
        else
        {
            Users.Add(newUser);
            Console.WriteLine($"{newUser.UserName} added.");
            NotificationService.SendNotificationOnSuccess($"Hello, a new user: {newUser.UserName} has been successfully added to the Library");
        }
    }

    public string FindBook(string title)
    {
        Book? foundBook = Books.Find(book => book.BookTitle == title);
        if (foundBook is not null) return $"Found : {foundBook.ToString()}";
        else return $"book ({title}) not found";
    }

    public string FindUser(string name)
    {
        // with Ienumerable: Users.First((user)=>user.UserName==name); //..> not nullable / Books.FirstOrDefault((user)=>user.UserName==name); ..>nullable
        User? foundUser = Users.Find(user => user.UserName == name);
        if (foundUser is not null) return $"{foundUser}";
        else return $"user ({name}) not found";
    }

    public void GetBooks()
    {
        var sortedBooks = from book in Books
                          orderby book.Date
                          select book;
        // other way for sorting : Books.orderBy((book)=>book.Date);

        foreach (var book in sortedBooks)
        {
            Console.WriteLine(book.ToString() + '\n');
        }
    }

    public void GetBooks(int page)
    {
        var sortedBooks = from book in Books
                          orderby book.Date
                          select book;

        var perPage = 5;
        var offset = (page - 1) * perPage;
        var paginated = sortedBooks.Skip(offset).Take(perPage);

        foreach (var book in paginated)
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

    public void GetUsers(int page)
    {
        var sortedUsers = from user in Users
                          orderby user.Date
                          select user;

        var perPage = 5;
        var offset = (page - 1) * perPage;
        var paginated = sortedUsers.Skip(offset).Take(perPage);

        foreach (var user in paginated)
        {
            Console.WriteLine(user.ToString() + '\n');
        }
    }

    public void DeleteBook(Guid id)
    {
        // with Ienumerable >> .where((book)=>book.id !=id);
        Book? foundBook = Books.Find(book => book.Id == id);
        if (foundBook is not null)
        {
            Books.Remove(foundBook);
            Console.WriteLine($"Hey, book with Id {id} deleted ");
            NotificationService.SendNotificationOnSuccess($"Hello, the book: {foundBook.BookTitle} has been successfully deleted from the Library");
        }
        else
        {
            Console.WriteLine("Book Not Found");
            NotificationService.SendNotificationOnFailure($"We encountered an issue deleting the book");
        }
    }

    public void DeleteUser(Guid id)
    {
        User? foundUser = Users.Find(user => user.Id == id);
        if (foundUser is not null)
        {
            Users.Remove(foundUser);
            Console.WriteLine($"Hey, user with Id {id} deleted ");
            NotificationService.SendNotificationOnSuccess($"Hello, the user: {foundUser.UserName} has been successfully deleted from the Library");
        }
        else
        {
            Console.WriteLine("User Not Found");
            NotificationService.SendNotificationOnFailure($"We encountered an issue deleting the user");
        }
    }

}
