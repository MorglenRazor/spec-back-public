using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.Core.Models
{
    public class ComponentsDevice
    {
        ComponentsDevice(int id, string name, string desc, int prior)
        {
            Id = id;
            Name = name;
            Description = desc;
            Prioritet = prior;
        }

        public static ComponentsDevice Create(int id, string name, string desc, int prior)
        {
            ComponentsDevice componentsDevice = new ComponentsDevice(id, name, desc, prior);
            return componentsDevice;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Prioritet { get; set; }

    }
}
