using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ErbiumCapstone.SignalR.Hubs
{
    public interface IHubContext<T>
    {
        IHubConnectionContext<T> Clients { get; set; }
        IGroupManager Groups { get; }
    }
}