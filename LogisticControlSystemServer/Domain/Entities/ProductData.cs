using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class ProductData
    {
        public int ProductDataId { get; set; }

        [Validate(pattern: @"^([а-яёА-ЯЁa-zA-Z]{2}-\d{8})$", minLength: 11, maxLength: 11)]
        [Description(title: "Арткул", hint: "Введите артикул в формате XX-12345678")]
        public string Article { get; set; }

        [IdTargetValue]
        [Validate(pattern: @"^([а-яёА-ЯЁa-zA-Z0-9]|\s)*$", maxLength: 60)]
        [Description(title: "Название", hint: "Введите название товара")]
        public string Name { get; set; }

        [Validate(pattern: @"^(\d+)$", maxLength: 20)]
        [Description(title: "Цена", hint: "Введите цену товара")]
        public int Cost { get; set; }
    }
}
