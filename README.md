# Email OTP module task

## Testing

<b>1. Clone repository into local, and run the project to launch swagger<br>
2. Project structure looks like this</b>

Controllers - EmailController (API endpoint)<br>

Service - EmailService (Logic held here)<br>
Service - EmailService, IInputStream (Simulate read from console)<br>
Service - IEmailService, IInputStream (Interface class)<br>

Utils - EmailEnum (Enums held here)<br>

<b>3. 2 endpoints are created for testing </b><br>
/Email/generate_OTP_email<br>
/Email/check_OTP<br>

<b>4. Assumptions</b>
- For generate_OTP_email, an API call is made to send the email address for validation, where the validation will take care of checking the email validity, while using the Random() class to generate a 6-digit code and returning it to the Swagger UI

- For check_OTP, an API call is made to take in the email address that the 6 digit was stored to. The method in the service Check_OTP takes in a input stream, which reads inputs from the console when required.


<b>5. To test generate_OTP_email, we will use 3 emails</b><br>
	- abc@outlook.com<br>
	-  </empty string, dont fill in anything><br>
	- pass@google.dso.org.sg<br>

The outcome will be
- Enum returned: STATUS_EMAIL_INVALID, OTP value generated: </no value generated>
- Enum returned: STATUS_EMAIL_FAIL, OTP value generated: </no value generated>
- Enum returned: STATUS_EMAIL_OK, OTP value generated: You OTP Code is XXXXXX. The code is valid for 1 minute

<b>7. Next to test check_OTP, we will key in the email address supplied in the first API to trigger the input from the console. We can now use the console to test input.</b>

<b>8. To test check_OTP, we perform 3 different types of scenario</b><br>
	- after input valid email, key in a different 6 digit value in the console, more than 10 times
	- leave the input hanging for more than 1 minute
	- key in OTP generated from the first API

The outcome will be
- STATUS_OTP_OK: OTP is valid and checked
- STATUS_OTP_FAIL: OTP is wrong after 10 tries
- STATUS_OTP_OK: OTP is valid and checked
