public class SMSNotificationService : INotificationService
{
    public void SendNotificationOnFailure(string failureMsg)
    {
        // Provides a short error notice and a suggestion to contact 
        // support via a different channel. 
        Console.WriteLine($"{failureMsg}. Please email support@library.com.");
    }

    public void SendNotificationOnSuccess(string successMsg)
    {
        // Sends a brief SMS with action confirmation and a short status update.
        Console.WriteLine($"{successMsg}  added to Library. Thank you!");
    }
}
