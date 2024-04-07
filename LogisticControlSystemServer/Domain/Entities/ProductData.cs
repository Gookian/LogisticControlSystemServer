using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class ProductData
    {
        public int ProductDataId { get; set; }

        [StringValue("Арткул")]
        public string Article { get; set; }

        [IdTargetValue]
        [StringValue("Название")]
        public string Name { get; set; }

        [StringValue("Цена")]
        public int Cost { get; set; }
    }
}
