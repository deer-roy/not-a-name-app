using Microsoft.AspNetCore.Mvc;
using name_app.Interfaces;
using name_app.Models;
using name_app.Services;

namespace name_app.Controllers;

[ApiController]
[Route("[controller]")]
public class SmsController : ControllerBase
{
    private readonly SmsService _smsService;

    public SmsController(SmsService smsService)
    {
        _smsService = smsService;
    }
    
    [HttpGet("messages")]
    public IList<Message> GetMessages() {
        return _smsService.GetMessages();
    }
    
    [HttpPost("messages")]
    public ActionResult GetMessages(
        [FromBody] SmsRequest request
    ) {
        try{
            _smsService.SendMessage(request.Recipient, request.Body);
            return Ok("Your message was sent.");
        } catch(ArgumentException exception) {
           return BadRequest(exception.Message); 
        }
    }
    
    public class SmsRequest {
        public string Recipient {get; set;} = null!;
        public string Body {get; set;} = null!;
    }
}
