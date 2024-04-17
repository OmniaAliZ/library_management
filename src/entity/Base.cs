public abstract class Base
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime Date { set; get; }
}