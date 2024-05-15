using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        [Validate(pattern: @"^[а-яёА-ЯЁa-zA-Z]+\s[а-яёА-ЯЁa-zA-Z]+\s[а-яёА-ЯЁa-zA-Z]+$", maxLength: 80)]
        [Description(title: "Владелец", hint: "Введите Фамилию Имя Отчество владельца")]
        public string Name { get; set; }

        [Validate(pattern: @"^([а-яёА-ЯЁa-zA-Z]|\s)*$", maxLength: 70)]
        [Description(title: "Тип", hint: "Введите тип транспортного средства")]
        public string Type { get; set; }

        [Validate(pattern: @"^([а-яёА-ЯЁa-zA-Z0-9]|\s)*$", maxLength: 60)]
        [Description(title: "Марка", hint: "Введите марку транспортного средства")]
        public string Brand { get; set; }

        [IdTargetValue]
        [Validate(pattern: @"^[АВЕКМНОРСТУХABEKMHOPCTYX]\s\d{3}(?<!000)\s[АВЕКМНОРСТУХABEKMHOPCTYX]{2}\s\d{2,3}$", minLength: 11, maxLength: 12)]
        [Description(title: "Регистрационный номер", hint: "Введите регистрационный номер в формате A 999 AA 700")]
        public string RegistrationNumber { get; set; }

        [Validate(pattern: @"^(\d+)$", maxLength: 25)]
        [Description(title: "Вместимость", hint: "Введите вместимость кузова в кв.м.")]
        public int Capacity { get; set; }

        [Validate(pattern: @"^(\d+)$", maxLength: 25)]
        [Description(title: "Грузоподемность", hint: "Введите грузоподъемность в тоннах")]
        public int LoadCapacity { get; set; }
    }
}
