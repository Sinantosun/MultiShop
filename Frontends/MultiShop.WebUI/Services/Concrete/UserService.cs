﻿using MultiShop.DtoLayer.Dtos.IdentityDtos.UserDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailViewModel> GetUserInfoAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/GetUserInfo");
            return values;
        }

        public async Task<List<ResultUserDto>> GetUserListAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultUserDto>>("/api/users/GetAllUserList");
            return values;
        }
    }
}
