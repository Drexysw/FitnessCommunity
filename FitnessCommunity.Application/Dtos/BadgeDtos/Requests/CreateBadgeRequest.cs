namespace FitnessCommunity.Application.Dtos.BadgeDtos.Requests
{
    public class CreateBadgeRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
