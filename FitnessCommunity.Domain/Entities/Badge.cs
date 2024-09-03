namespace FitnessCommunity.Domain.Entities
{
    public class Badge : BaseEntity.BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = [];
    }
}
