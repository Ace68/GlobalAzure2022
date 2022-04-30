﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GlobalAzure2022.Wasm.Shared.Abstracts;
using GlobalAzure2022.Wasm.Shared.JsonModel.Common;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace GlobalAzure2022.Wasm.Shared.Concretes
{
    public sealed class TokenService : ITokenService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public TokenService(ILocalStorageService localStorageService,
            HttpClient httpClient,
            NavigationManager navigationManager)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task StoreTokenAsync(string accessToken)
        {
            await _localStorageService.SetItem("token", accessToken);
        }

        public async Task<TokenJson> DecodeAndStoreTokenAsync(string accessToken)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwt = (JwtSecurityToken)jwtSecurityTokenHandler.ReadToken(accessToken);

            var token = new TokenJson();

            if (jwt is null)
                return token;

            token.ValidFrom = jwt.ValidFrom;
            token.ValidTo = jwt.ValidTo;
            token.AccessToken = accessToken;

            foreach (var claim in jwt.Claims)
            {
                if (claim.Type.ToLower().Equals("accessToken"))
                    token.AccessToken = claim.Value;

                if (claim.Type.ToLower().Equals("platforms"))
                    token.Platforms = claim.Value;

                if (claim.Type.ToLower().Equals("company"))
                    token.Company = claim.Value;
            }

            await _localStorageService.SetItem("token", token.AccessToken);

            return token;
        }

        public TokenJson DecodeToken(string accessToken)
        {
            var token = new TokenJson();

            if (string.IsNullOrWhiteSpace(accessToken))
                return token;

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwt = (JwtSecurityToken)jwtSecurityTokenHandler.ReadToken(accessToken);

            if (jwt is null)
                return token;

            token.ValidFrom = jwt.ValidFrom;
            token.ValidTo = jwt.ValidTo;

            foreach (var claim in jwt.Claims)
            {
                if (claim.Type.ToLower().Equals("accessToken"))
                    token.AccessToken = claim.Value;

                if (claim.Type.ToLower().Equals("platforms"))
                    token.Platforms = claim.Value;

                if (claim.Type.ToLower().Equals("company"))
                    token.Company = claim.Value;
            }

            return token;
        }

        public async Task RefreshToken()
        {
            var accessToken = await _localStorageService.GetItem<string>("token");
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                _navigationManager.NavigateTo("/");
                return;
            }

            var request = new HttpRequestMessage(HttpMethod.Post, "/v1/Tokens/getnewtoken");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            
            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var tokenJson = JsonConvert.DeserializeObject<TokenJson>(content);
            if (tokenJson is null)
            {
                _navigationManager.NavigateTo("/");
                return;
            }

            await DecodeAndStoreTokenAsync(tokenJson.AccessToken);
        }

        public async Task<bool> IsValidAsync()
        {
            var accessToken = await _localStorageService.GetItem<string>("token");
            if (string.IsNullOrWhiteSpace(accessToken))
                return false;

            var token = DecodeToken(accessToken);
            return token.ValidTo >= DateTime.UtcNow;
        }
    }
}