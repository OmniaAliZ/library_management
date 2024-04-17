public class EmailNotificationService : INotificationService
{
    public void SendNotificationOnFailure(Base? item = null)
    {
        // Provides a detailed error report, 
        // troubleshooting steps, and a link to an FAQ or help page.
        if (item is not null)
        {
            Console.WriteLine($"We encountered an issue adding {item.Id}. Please review the input data. For more help, visit our FAQ at library.com/faq.");
        }
        else
        {
            Console.WriteLine($"We encountered an issue. Please review the input data. For more help, visit our FAQ at library.com/faq.");
        }
    }

    public void SendNotificationOnSucess(Base? item = null)
    {
        // Sends a comprehensive email, including action details,
        // a summary of the item, user feedback instructions, and a support contact.
        if (item is not null)
        {
            Console.WriteLine($"Hello, a new {item.Id} has been successfully added to the Library. If you have any queries or feedback, please contact our support team at support@library.com.");
        }
        else
        {
            Console.WriteLine($"Hello, added to the Library successfully. If you have any queries or feedback, please contact our support team at support@library.com.");
        }
    }
}
