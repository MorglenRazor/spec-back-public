using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using Specification.Core.Abstractions.Service.Auth;
using System.Text.Json;


namespace Specification.API.Hubs
{
    public class NotificationHub : Hub<IChatClient>
    {
        private readonly IDistributedCache _cache;
        private readonly IUserService _userService;

        public NotificationHub(IDistributedCache cache, 
            IUserService userService)
        {
            _cache = cache;
            _userService = userService;
        }
        static HashSet<string> CurrentConnections = new HashSet<string>();

        //https://stackoverflow.com/questions/62052494/signalr-how-can-i-get-access-to-claims-from-connected-users

        public async Task JoinToNotificationHub(UserConnection connection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, connection.GroupName);

            var stringConnection = JsonSerializer.Serialize(connection);

            await _cache.SetStringAsync(Context.ConnectionId, stringConnection);

            await Clients.Group(connection.GroupName).ReceiveNotification("Admin", "ВЫ присоединились к группе");
        }

        public async Task SendNotification(string empId)
        {
            var stringConnection = await _cache.GetAsync(Context.ConnectionId);
            var connection = JsonSerializer.Deserialize<UserConnection>(stringConnection);
            if (connection is not null)
            {
                await Clients.Group(connection.GroupName)
                    .ReceiveNotification(empId, "Test");
            }
        }

        public async Task SendRefreshPage()
        {
            await this.Clients.All.RefreshPage();
        }

    }
    public class UserConnection{
        public Guid UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string GroupName { get; set; } = string.Empty;
    }
}

