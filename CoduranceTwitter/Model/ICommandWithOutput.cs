using System.Collections.Generic;

namespace CoduranceTwitter.Model
{
    public interface ICommandWithOutput : ICommand
    {
        List<Message> Messages { get; }
    }
}
