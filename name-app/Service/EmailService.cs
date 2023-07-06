using name_app.Interfaces;
using name_app.Models;

namespace name_app.Services;


public class EmailService : IMessageService
{
    
    private readonly List<Message> messages = new();

    public IList<Message> GetMessages() {
        return messages;
    }

    public void SendMessage(string recipient, string body) {
        if(string.IsNullOrEmpty(body)) {
            throw new ArgumentException("Body cannot be empty", nameof(body));    
        }
        
        if(recipient.Length < 5 || recipient.Length > 100) {
            throw new ArgumentException("Invalid recipient", nameof(recipient));    
        }

        messages.Add(new Message{
            Recipient = recipient,
            Body = body
        });
    }
}