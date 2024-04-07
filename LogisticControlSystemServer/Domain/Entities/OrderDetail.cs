using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        [StringValue("Количество")]
        public int Count { get; set; }

        // Внешние ключи
        [StringValue("Номер заказ")]
        public int OrderId { get; set; }

        [StringValue("Тип товара")]
        public int ProductDataId { get; set; }

        // Ссылки на объекты внешнего ключа
        public Order? Order { get; set; }
        public ProductData? ProductData { get; set; }
    }
}
