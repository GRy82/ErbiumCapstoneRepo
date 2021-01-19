using System.Threading.Tasks;

namespace ErbiumCapstone.SignalR.Hubs
{
    public interface ITypedClient
    {
        void Test();
        Task BroadcastMessage(string v, string user, string message);
        Task BroadcastMessage(string user, string message);
    }
}