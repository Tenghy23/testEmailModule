using Microsoft.AspNetCore.Mvc;
using testEmailModule.Service;

namespace testEmailModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        // @func generate_OTP_email sends a new 6 digit random OTP code to the given email address input by the users
        [HttpGet("generate_OTP_email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Generate_OTP_email(string? email)
        {
            try
            {
                var response = await _emailService.generate_OTP_email(email);
                return Ok($"Enum returned: {response.Item1}, OTP value generated: {response.Item2}");
            }
            catch 
            {
                throw new Exception("Generate OTP for email is unsuccessful, please try again later");
            }
        }

        // @func check_OTP reads the input stream for user input of the OTP.
        [HttpPost("check_OTP")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Check_OTP([FromBody] string? OTPInput, bool retry = false)
        {
            try
            {
                using (var stream = HttpContext.Request.Body)
                {
                    var result = await _emailService.check_OTP(stream, retry, OTPInput);
                    return Ok($"Enum: {(int)result.Item1}, Message: {result.Item2}");
                }
            }
            catch
            {
                throw new Exception("Check OTP for email is unsuccessful");
            }
        }
    }
}
