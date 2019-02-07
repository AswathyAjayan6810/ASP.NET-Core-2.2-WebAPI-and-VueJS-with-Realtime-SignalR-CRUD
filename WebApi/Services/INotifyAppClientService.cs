using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface INotifyAppClientService
    {
        Task Notify(string message);
    }
}