namespace CoduranceTwitter
{
    public interface ICommand
    {
        bool Process(string command);
    }
}
