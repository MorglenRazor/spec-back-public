using Microsoft.AspNetCore.SignalR;

namespace Specification.API.Hubs
{

    public interface IDefaulHub
    {
        public Task RefreshPage();
    }
    public class DefaultHub : Hub<IDefaulHub>
    {
        public async Task SendRefreshPage()
        {
            await Clients.All.RefreshPage();
        }
    }
}
