using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalAzure2022.Wasm.Shared.JsonModel.Accounts
{
    public class AccountJson
    {
        public string AccountId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public CompanyAccountJson Company { get; set; } = new();

        public MasterDataJson MasterData { get; set; } = new();

        public IEnumerable<ContactJson> Contacts { get; set; } = Enumerable.Empty<ContactJson>();

        public IEnumerable<PlatformJson> Platforms { get; set; } = Enumerable.Empty<PlatformJson>();

        public RoleJson Role { get; set; } = new();

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}