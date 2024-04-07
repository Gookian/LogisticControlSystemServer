using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        [StringValue("Имя")]
        public string FirstName { get; set; }

        [StringValue("Фамилия")]
        public string MiddleName { get; set; }

        [StringValue("Отчество")]
        public string? Surname { get; set; }

        [StringValue("Адрес")]
        public string Address { get; set; }

        [StringValue("Дата доставки")]
        public DateTime DeliveryDateTime { get; set; }
    }
}
