﻿namespace FitnessCommunity.Application.Dtos.UserDtos.Requests
{
    public class LoginUserRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
