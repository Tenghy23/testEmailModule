using testEmailModule.Utils;

namespace testEmailModule.Service
{
    public interface IEmailService
    {
        Task<(EmailEnum, string)> generate_OTP_email(string? email);
        Task<(EmailEnum, string)> Check_OTP(IInputStream input, string email);
    }
}