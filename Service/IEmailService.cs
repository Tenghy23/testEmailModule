using testEmailModule.Utils;

namespace testEmailModule.Service
{
    public interface IEmailService
    {
        Task<(EmailEnum, string)> generate_OTP_email(string? email);
        Task<(EmailEnum, string)> check_OTP(Stream input, bool retry = false, string? OTPInputFromUser = null);
    }
}