using Muflone.Core;

namespace GlobalAzure2022.Modules.Production.Extensions.CustomTypes;

public class BeerId : DomainId
{
    public BeerId(Guid value) : base(value)
    {
    }
}