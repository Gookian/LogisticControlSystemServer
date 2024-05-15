using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class Flight
    {
        public int FlightId { get; set; }

        [IdTargetValue]
        public string Number { get; set; }

        // Внешние ключи
        [Validate(pattern: @"^(\d+)$")]
        [Description(title: "Транспортное средство", hint: "Выберите транспортное средство")]
        public int VehicleId { get; set; }

        // Ссылки на объекты внешнего ключа
        public Vehicle? Vehicle { get; set; }
    }
}
