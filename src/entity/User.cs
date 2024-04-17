public class User : Base
{
    public string UserName { set; get; }
    public User(string name, DateTime? dateTime = null)
    {
        UserName = name;
        Date = dateTime is null ? DateTime.Now : (DateTime)dateTime;
    }
    public override string? ToString()
    {
        return $"User ({Id})\nName: {UserName}\nCreated date: {Date}\n";
    }
}