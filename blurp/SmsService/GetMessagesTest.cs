using Xunit;
using name_app.Services;

namespace blurp;

public class GetMessagesTest {
    
    [Fact]
    public void Returns_a_list_of_messages()
    {
        // Given
        var smsService = new SmsService();
    
        // When
        smsService.GetMessages();
    }

}