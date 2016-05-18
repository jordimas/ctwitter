using System.Collections.Generic;
using CoduranceTwitter.Model.Messages;

namespace CoduranceTwitter.Model
{
    public interface ICommandWithOutput : ICommand
    {
        List<Message> Messages { get; }
    }
}
