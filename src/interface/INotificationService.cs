public interface INotificationService
{
    // public void SendNotificationOnSucess(Base? entity = null);
    // public void SendNotificationOnFailure(Base? entity = null);

    public void SendNotificationOnSuccess(string successMsg);
    public void SendNotificationOnFailure(string failureMsg);
}