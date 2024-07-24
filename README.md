# Email OTP module task

## Testing

<b>1. Clone repository into local, and run the project to launch swagger<br>
2. Project structure looks like this</b>

Controllers - EmailController (API endpoint)<br>

Service - EmailService (Logic held here)<br>
Service - IEmailService (Interface class)<br>

Utils - EmailEnum (Enums held here)<br>

<b>3. 2 endpoints are created for testing </b><br>
/Email/generate_OTP_email<br>
/Email/check_OTP<br>

<b>4. Assumptions</b>
- For generate_OTP_email, an API call is made to send the email address for validation, where the validation will take care of checking the email validity, while using the Random() class to generate a 6-digit code and returning it to the front end

- For check_OTP, an API call is made to take in the 6-digit code that was generated. The method in the service check_OTP takes in a generic stream, and nullable parameters for simulating testing purposes

check_OTP(Stream input, bool retry = false, string? OTPInputFromUser = null)

the retry parameter is meant for the purpose of simulating retry logic
the OTPInputFromUser parameter is meant to pass in the 6-digit generated from the generate_OTP_email to validate

the check_OTP method will read the input stream for user input of the OTP. From the output of the input stream, we will check it with the 6-digit that was passed in by the user [OTPInputFromUser]. The service is registered as a singleton in order for the numberOfTries count to persist between API calls, and 10 tries validation and timeout validation are implemented as such

<b>6. first to test generate_OTP_email, we will use 3 emails</b><br>
	- abc@outlook.com<br>
	-  </empty string, dont fill in anything><br>
	- pass@google.dso.org.sg<br>

The outcome will be
- Enum returned: STATUS_EMAIL_INVALID, OTP value generated: </no value generated>
- Enum returned: STATUS_EMAIL_FAIL, OTP value generated: </no value generated>
- Enum returned: STATUS_EMAIL_OK, OTP value generated: You OTP Code is 158488. The code is valid for 1 minute

<b>7. Next to test check_OTP, we will use these three methods of testing</b>

<u>to test successful flow... [STATUS_OTP_OK: OTP is valid and checked]</u>
- "158488" </ valid number which was generated, retry = false>

<u>to test fail flow... [STATUS_OTP_FAIL: OTP is wrong after 10 tries]</u>
- step 1. call API with "158488" </set retry = true>, and do not close the project
- step 2. call API with "158488" </set retry = false>
you will notice that numberOfTries count will be set to 10 in the second call, because in the first call, we have persisted the value, and hence the outcome will show   
 Enum: 5, Message: STATUS_OTP_FAIL

<u>to test timeout... [STATUS_OTP_TIMEOUT: timeout after 1 min]</u>
- step 1. Restart the project, go to EmailService and uncomment line 102 [delay 61 seconds]
- step 2. comment line 101 [delay 1 seconds]
- step 3. call API with "158488" </set retry = false>, and wait 61 seconds for the call to finish
you will notice that the error thrown out would be the delay message Enum: 6, Message: STATUS_OTP_TIMEOUT