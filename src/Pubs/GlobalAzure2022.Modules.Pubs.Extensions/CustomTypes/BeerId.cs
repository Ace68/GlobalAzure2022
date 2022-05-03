using Muflone.Core;

namespace GlobalAzure2022.Modules.Pubs.Extensions.CustomTypes;

public class BeerId : DomainId
{
    public BeerId(Guid value) : base(value)
    {
    }
}