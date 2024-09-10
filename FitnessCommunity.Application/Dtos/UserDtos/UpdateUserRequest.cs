﻿namespace FitnessCommunity.Application.Dtos.UserDtos
{
    public class UpdateUserRequest
    {

        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
