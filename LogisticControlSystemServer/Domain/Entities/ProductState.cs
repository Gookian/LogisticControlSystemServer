using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class ProductState
    {
        public int ProductStateId { get; set; }

        [IdTargetValue]
        public string Name { get; set; }
    }
}
