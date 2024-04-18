public class Book : Base
{
    public string BookTitle { set; get; }
    public BookTypes Type { set; get; }

    public Book(string title, BookTypes type, DateTime? dateTime = null)
    {
        Type = type;
        BookTitle = title;
        Date = dateTime is null ? DateTime.Now : (DateTime)dateTime;
    }

    public Book(string title, DateTime? dateTime = null)
    {
        BookTitle = title;
        Date = dateTime is null ? DateTime.Now : (DateTime)dateTime;
    }

    public override string? ToString()
    {
        return $"\nBook ({Id})\nName: {BookTitle} | Created date: {Date}\n";
    }

}