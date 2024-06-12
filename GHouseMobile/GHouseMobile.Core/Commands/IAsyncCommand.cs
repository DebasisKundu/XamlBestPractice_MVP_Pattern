using System.Threading.Tasks;
using System.Windows.Input;

namespace GHouseMobile.Core.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
    }

    public interface IAsyncCommand<T> : ICommand
    {
        Task ExecuteAsync(T parameter);
    }
}
