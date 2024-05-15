using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        [Validate(pattern: @"^([а-яёА-ЯЁa-zA-Z]|\s)*$", maxLength: 60)]
        [Description(title: "Фамилия", hint: "Выберите фамилию")]
        public string MiddleName { get; set; }

        [Validate(pattern: @"^([а-яёА-ЯЁa-zA-Z]|\s)*$", maxLength: 60)]
        [Description(title: "Имя", hint: "Выберите имя")]
        public string FirstName { get; set; }

        [Validate(pattern: @"^([а-яёА-ЯЁa-zA-Z]|\s)*$", maxLength: 60)]
        [Description(title: "Отчество", hint: "Выберите отчество")]
        public string? Surname { get; set; }

        [Validate(pattern: @"^([а-яёА-ЯЁa-zA-Z0-9]|\s|[,.])*$", maxLength: 70)]
        [Description(title: "Адрес", hint: "Выберите адрес доставик")]
        public string Address { get; set; }

        [Validate(pattern: @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.(\d{4})\s(0[1-9]|[1][0-9]|2[0-3])\:(0[1-9]|[1-5][0-9])\:(0[1-9]|[1-5][0-9])$", minLength: 19, maxLength: 19)]
        [Description(title: "Дата доставки", hint: "Введите дату в формате 31.12.2024 23:59:59")]
        public DateTime DeliveryDateTime { get; set; }
    }
}
