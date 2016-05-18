namespace CoduranceTwitter.Model
{
    public interface ICommand
    {
        bool Process(string command);
    }
}
