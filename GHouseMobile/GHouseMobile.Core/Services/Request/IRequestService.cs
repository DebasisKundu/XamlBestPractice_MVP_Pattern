using System.Threading.Tasks;

namespace GHouseMobile.Core.Services.Request
{
    public interface IRequestService
    {
        Task<TResult> GetAsync<TResult>(string uri, string? token = "");

        Task<TResult> Post<TResult>(string uri, TResult data, string? token = "");

        Task<TResult> Post<TRequest, TResult>(string uri, TRequest data, string? token = "");
    }
}
