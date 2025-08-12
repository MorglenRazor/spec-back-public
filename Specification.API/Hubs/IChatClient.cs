namespace Specification.API.Hubs
{
    public interface IChatClient
    {
        public Task ReceiveNotification(string users, string textMessage);

        public Task SendNotification(Guid userId, string notificationText);

        public Task SendNotification(Guid[] empIdForNotification);

        public Task RefreshPage();

        public Task RecalckNtf();
    }
}
