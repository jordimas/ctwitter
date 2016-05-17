using CoduranceTwitter.Model;
using System.Collections.Generic;

namespace CoduranceTwitter
{
    public interface ICommandWithOutput : ICommand
    {
        List<Message> Output { get; }
    }
}
