using LogisticControlSystemServer.Domain.Entities.Attributes;

namespace LogisticControlSystemServer.Domain.Entities
{
    public class PackageState
    {
        public int PackageStateId { get; set; }

        [IdTargetValue]
        public string Name { get; set; }
    }
}
