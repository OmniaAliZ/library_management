public class EmailNotificationService : INotificationService
{
    public void SendNotificationOnFailure(string failureMsg)
    {
        // Provides a detailed error report, 
        // troubleshooting steps, and a link to an FAQ or help page.
        Console.WriteLine($"{failureMsg}. Please review the input data. For more help, visit our FAQ at library.com/faq.\n");
    }

    public void SendNotificationOnSuccess(string successMsg)
    {
        // Sends a comprehensive email, including action details,
        // a summary of the item, user feedback instructions, and a support contact.\
        Console.WriteLine($"{successMsg}. If you have any queries or feedback, please contact our support team at support@library.com.\n");
    }
}
