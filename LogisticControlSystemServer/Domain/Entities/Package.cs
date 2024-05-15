using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class Package
    {
        public int PackageId { get; set; }

        [IdTargetValue]
        [Validate(pattern: @"^(\d+)$", minLength: 8, maxLength: 10)]
        [Description(title: "Номер", hint: "Введите номер посылки")]
        public int Number { get; set; }

        [Validate(pattern: @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.(\d{4})\s(0[1-9]|[1][0-9]|2[0-3])\:(0[1-9]|[1-5][0-9])\:(0[1-9]|[1-5][0-9])$", minLength: 19, maxLength: 19)]
        [Description(title: "Дедлайн сборки", hint: "Введите дату в формате 31.12.2024 23:59:59")]
        public DateTime BuildDeadline { get; set; }

        // Внешние ключи
        [Validate(pattern: @"^(\d+)$")]
        [Description(title: "Состояние", hint: "Выберите состояние")]
        public int PackageStateId { get; set; }

        // Ссылки на объекты внешнего ключа
        public PackageState? PackageState { get; set; }
    }
}
