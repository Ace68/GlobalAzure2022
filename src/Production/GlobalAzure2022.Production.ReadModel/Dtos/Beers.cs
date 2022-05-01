using GlobalAzure2022.Modules.Production.Extensions.CustomTypes;
using GlobalAzure2022.Modules.Production.Extensions.JsonRequests;
using GlobalAzure2022.Production.ReadModel.Abstracts;

namespace GlobalAzure2022.Production.ReadModel.Dtos;

public class Beers : DtoBase
{
    public string BeerType { get; private set; } = string.Empty;
    public double Quantity { get; private set; } = 0;

    protected Beers()
    {}

    public static Beers CreateBeers(BeerId beerId, BeerType beerType, BeerQuantity quantity) =>
        new(beerId.ToString(), beerType.Value, quantity.Value);

    private Beers(string beerId, string beerType, double quantity)
    {
        Id = beerId;
        BeerType = beerType;
        Quantity = quantity;
    }

    public BeersJson ToJson() => new ()
    {
        Id = Id,
        BeerType = BeerType,
        Quantity = Quantity
    };
}