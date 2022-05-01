namespace GlobalAzure2022.Production.ReadModel.Abstracts;

public interface IDtoBase
{
    string Id { get; }
    bool IsDeleted { get; }
}