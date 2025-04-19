using SensorService.Application.Interfaces;
using SensorService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SensorService.Infrastructure.Repositories;

public class InMemoryVehicleEventRepository : IVehicleEventRepository
{
    private readonly List<VehicleEvent> _events = new();

    public void Add(VehicleEvent vehicleEvent) => _events.Add(vehicleEvent);

    public IEnumerable<VehicleEvent> GetAll() => _events;
}
