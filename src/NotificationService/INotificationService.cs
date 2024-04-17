public interface INotificationService
{
    public void SendNotificationOnSucess(Base? entity = null);
    public void SendNotificationOnFailure(Base? entity = null);

    // public void SendNotificationOnSucess(string item);
    // public void SendNotificationOnFailure(string item);
}