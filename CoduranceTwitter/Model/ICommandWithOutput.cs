namespace CoduranceTwitter
{
    public interface ICommandWithOutput : ICommand
    {
        string[] Output { get; }
    }
}
