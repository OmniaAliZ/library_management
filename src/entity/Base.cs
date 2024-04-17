public abstract class Base
{
    public Guid Id = Guid.NewGuid();
    public DateTime Date { set; get; }
}