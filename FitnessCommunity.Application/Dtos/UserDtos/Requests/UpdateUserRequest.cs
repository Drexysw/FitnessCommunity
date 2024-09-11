using FitnessCommunity.Application.Dtos.UserDtos.Requests.Base;

namespace FitnessCommunity.Application.Dtos.UserDtos.Requests
{
    public class UpdateUserRequest : BaseUserRequest
    {
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
    }
}
