public class SMSNotificationService : INotificationService
{
    public void SendNotificationOnFailure(Base? item = null)
    {
        // Provides a short error notice and a suggestion to contact 
        // support via a different channel. 
        if (item is not null)
            Console.WriteLine($"Error adding {item.Id}. Please email support@library.com.");
        else Console.WriteLine($"Error adding the item. Please email support@library.com.");
    }

    public void SendNotificationOnSucess(Base? item = null)
    {
        // Sends a brief SMS with action confirmation and a short status update.
        if (item is not null)
            Console.WriteLine($"{item.Id}  added to Library. Thank you!");
        else Console.WriteLine($"Item added to Library. Thank you!");
    }
}
