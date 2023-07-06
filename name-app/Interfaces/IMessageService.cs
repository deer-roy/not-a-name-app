using name_app.Models;

namespace name_app.Interfaces;

public interface IMessageService {
    public void SendMessage(string recipient, string body);
    
    public IList<Message> GetMessages();
}
