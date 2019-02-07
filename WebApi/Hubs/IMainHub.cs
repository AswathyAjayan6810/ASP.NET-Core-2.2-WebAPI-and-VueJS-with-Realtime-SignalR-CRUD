using System.Threading.Tasks;

namespace WebApi.Hubs
{
    public interface IMainHub
    {
        Task NotifyAllClients();
    }
}