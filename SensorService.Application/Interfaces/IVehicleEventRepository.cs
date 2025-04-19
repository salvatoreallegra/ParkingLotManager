using SensorService.Domain.Entities;

namespace SensorService.Application.Interfaces;

public interface IVehicleEventRepository
{
    void Add(VehicleEvent vehicleEvent);
    IEnumerable<VehicleEvent> GetAll();
}
