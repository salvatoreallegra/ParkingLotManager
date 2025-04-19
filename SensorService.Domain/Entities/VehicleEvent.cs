using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorService.Domain.Entities
{
    public class VehicleEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string LicensePlate { get; set; } = string.Empty;
        public string SensorId { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string EventType { get; set; } = "Entry"; // or "Exit"
    }
}
