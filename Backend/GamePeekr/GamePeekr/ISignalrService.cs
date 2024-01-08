namespace GamePeekr
{
    public interface ISignalrService
    {
        Task SendMessageToAllClients(string message);
    }
}
