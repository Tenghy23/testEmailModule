namespace testEmailModule.Service
{
    public interface IInputStream
    {
        Task<string> ReadOTPAsync(CancellationToken token);
    }

}
