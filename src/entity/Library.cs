public class Library
{
    public List<Book> books;
    public List<User> users;
    public Library()
    {
        books = new List<Book>();
        users = new List<User>();
    }
    public void AddBook(Book newBook)
    {
        if (books.Contains(newBook))
        {
            Console.WriteLine($"{newBook.BookTitle} Already exists.");
        }
        else
        {
            books.Add(newBook);
            Console.WriteLine($"{newBook.BookTitle} added.");
        }
    }
    public void AddUser(User newUser)
    {
        if (users.Contains(newUser))
        {
            Console.WriteLine($"{newUser.UserName} Already exists.");
        }
        else
        {
            users.Add(newUser);
            Console.WriteLine($"{newUser.UserName} added.");
        }
    }
    string FindBook(string title)
    {
        Book? foundBook = books.Find(book => book.BookTitle == title);
        return $"{foundBook}";
    }
    string FindUser(string name)
    {
        User? foundUser = users.Find(user => user.UserName == name);
        return $"{foundUser}";
    }
    public void DeleteBook(Guid id)
    {
        Book? foundBook = books.Find(book => book.Id == id);
        if (foundBook is not null)
        {
            books.Remove(foundBook);
            Console.WriteLine($"Hey, book with Id {id} deleted ");
        }
        else
        {
            Console.WriteLine("Book Not Found");
        }
    }
    public void DeleteUser(Guid id)
    {
        User? foundUser = users.Find(user => user.Id == id);
        if (foundUser is not null)
        {
            users.Remove(foundUser);
            Console.WriteLine($"Hey, user with Id {id} deleted ");
        }
        else
        {
            Console.WriteLine("User Not Found");
        }
    }
    public void GetBooks()
    {
        var sortedBooks = from book in books
                          orderby book.Date
                          select book;
        foreach (var book in sortedBooks)
        {
            Console.WriteLine(book.ToString() + '\n');
        }
    }
    public void GetUsers()
    {
        var sortedUsers = from user in users
                          orderby user.Date
                          select user;
        foreach (var user in users)
        {
            Console.WriteLine(user.ToString() + '\n');
        }
    }

}
