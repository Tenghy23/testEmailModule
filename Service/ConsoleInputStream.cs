using System;
using System.Net.Http;
using System.Threading.Tasks;
using testEmailModule.Service;

public class ConsoleInputStream : IInputStream
{
    public ConsoleInputStream() { }

    /// <summary>
    /// Reads OTP from the console input asynchronously.
    /// </summary>
    /// <returns>The OTP entered by the user.</returns>
    public async Task<string> ReadOTPAsync(CancellationToken token)
    {
        Console.WriteLine("Enter OTP: ");

        // Simulate waiting for input asynchronously
        return await Task.Run(() =>
        {
            token.ThrowIfCancellationRequested();
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }, token);
    }

}
