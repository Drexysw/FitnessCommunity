namespace FitnessCommunity.Application.Dtos.BadgeDtos.Requests
{
    public class UpdateBadgeRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
