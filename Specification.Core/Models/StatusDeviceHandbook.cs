namespace Specification.Core.Models
{
    public class StatusDeviceHandbook
    {




        /// <summary>
        /// Создание нового статуса
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="depid"></param>
        public StatusDeviceHandbook(
            Guid id,
            string name,
            Guid depid, bool isVisible, short rank)
        {
            Id = id;
            Name = name;
            DepId = depid;
            IsVisible = isVisible;
            Rank = rank;
        }

        public static StatusDeviceHandbook Create(Guid id, string name, Guid depId, bool isVisible, short rank)
        {
            StatusDeviceHandbook status = new StatusDeviceHandbook(id, name, depId, isVisible, rank);
            return status;
        }

        public StatusDeviceHandbook(
            Guid id,
            string name,
            Guid depId,
            string depName, bool isVisible, short rank)
        {
            Id = id;
            Name = name;
            DepId = depId;
            DepName = depName;
            IsVisible = isVisible;
            Rank = rank;
        }

        public static StatusDeviceHandbook GetModel(Guid id, string name, Guid depId, string depName, bool isVisible, short rank)
        {
            StatusDeviceHandbook status = new StatusDeviceHandbook(id,name,depId,depName, isVisible, rank);
            return status;
        }

        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public Guid DepId { get; }
        public string DepName { get; } = string.Empty;
        public bool IsVisible { get; set; }
        public short Rank { get; set; } = 0;


    }
}
