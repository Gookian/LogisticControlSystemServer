using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class Package
    {
        public int PackageId { get; set; }

        [IdTargetValue]
        [StringValue("Номер")]
        public int Number { get; set; }

        [StringValue("Дедлайн сборки")]
        public DateTime BuildDeadline { get; set; }

        // Внешние ключи
        [StringValue("Состояние")]
        public int PackageStateId { get; set; }

        // Ссылки на объекты внешнего ключа
        public PackageState? PackageState { get; set; }
    }
}
