using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class Flight
    {
        public int FlightId { get; set; }

        [IdTargetValue]
        public string Number { get; set; }

        // Внешние ключи
        [StringValue("Транспортное средство")]
        public int VehicleId { get; set; }

        // Ссылки на объекты внешнего ключа
        public Vehicle? Vehicle { get; set; }
    }
}
