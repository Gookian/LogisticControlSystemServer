using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        // Внешние ключи
        [StringValue("Тип товара")]
        public int ProductDataId { get; set; }

        [StringValue("Состояние товара")]
        public int ProductStateId { get; set; }

        // Ссылки на объекты внешнего ключа
        public ProductData? ProductData { get; set; }
        public ProductState? ProductState { get; set; }
    }
}
