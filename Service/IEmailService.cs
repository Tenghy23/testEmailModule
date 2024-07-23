using testEmailModule.Utils;

namespace testEmailModule.Service
{
    public interface IEmailService
    {
        Task<(EmailEnum, string)> generate_OTP_email(string? email);
        Task<EmailEnum> check_OTP(StreamReader input, string generatedOTP);
    }
}