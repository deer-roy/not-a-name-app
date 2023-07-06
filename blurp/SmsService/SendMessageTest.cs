using Xunit;
using name_app.Services;

namespace blurp;

public class SendMessageTest {
    
    [Fact]
    public void Sends_a_message()
    {
        // Given
        var smsService = new SmsService();
        var smsListBefore = smsService.GetMessages();
        var expectedSmsCount = smsListBefore.Count() + 1;
    
        // When
        smsService.SendMessage("12345", "This is it");
        var smsListAfter = smsService.GetMessages();
    
        // Then
        Assert.Equal(expectedSmsCount, smsListAfter.Count());
    }

    
    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("12")]
    [InlineData("123")]
    [InlineData("1234")]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab")]
    public void Sending_a_message_without_an_invalid_recipient_throws_an_exception(
        string recipient
    )
    {
        // Given
        var smsService = new SmsService();
    
        // When
        var exception = Assert.Throws<ArgumentException>(
            () => smsService.SendMessage(recipient, "here's a message")
        );
    
        // Then
        Assert.Equal("recipient", exception.ParamName);
    }
    
    [Fact]
    public void Sending_a_message_without_a_body_throws_an_exception()
    {
        // Given
        var smsService = new SmsService();

        // When
        var exception = Assert.Throws<ArgumentException>(() => smsService.SendMessage("1234567", ""));
    
        // Then
        Assert.Equal("body", exception.ParamName);
    }
}