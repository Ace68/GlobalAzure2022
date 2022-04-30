using System;

namespace GlobalAzure2022.Wasm.Shared.JsonModel.Common
{
    public class TokenJson
    {
        public string AccessToken { get; set; }

        public string Platforms { get; set; }
        public string Company { get; set; }

        public int Expiration { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

    }
}