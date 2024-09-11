namespace FitnessCommunity.Application.Dtos.BadgeDtos.Requests.Base
{
    public abstract class BaseBadgeRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public int WorkoutsRequired { get; set; }
    }
}
