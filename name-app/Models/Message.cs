namespace name_app.Models;

public class Message {

    public Guid MessageId {get; set;}
    public string Recipient {get; set;} = null!;
    public string Body { get; set;} = null!;
}