using System.Threading.Tasks;
using GlobalAzure2022.Wasm.Shared.JsonModel.Common;

namespace GlobalAzure2022.Wasm.Shared.Abstracts
{
    public interface ITokenService
    {
        Task StoreTokenAsync(string accessToken);
        Task<TokenJson> DecodeAndStoreTokenAsync(string accessToken);
        TokenJson DecodeToken(string accessToken);
        Task RefreshToken();

        Task<bool> IsValidAsync();
    }
}