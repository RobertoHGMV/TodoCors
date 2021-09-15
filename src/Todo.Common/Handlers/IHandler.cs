using Todo.Common.Commands;

namespace Todo.Common.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
