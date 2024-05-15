using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        // Внешние ключи
        [Validate(pattern: @"^(\d+)$")]
        [Description(title: "Тип товара", hint: "Выберите тип твара")]
        public int ProductDataId { get; set; }

        [Validate(pattern: @"^(\d+)$")]
        [Description(title: "Состояние товара", hint: "Выберите состояние товара")]
        public int ProductStateId { get; set; }

        // Ссылки на объекты внешнего ключа
        public ProductData? ProductData { get; set; }
        public ProductState? ProductState { get; set; }
    }
}
