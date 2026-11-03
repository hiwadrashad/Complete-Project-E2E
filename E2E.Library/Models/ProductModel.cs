using E2E.Library.Enums;

namespace E2E.Library.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public MenClothingSizeEnum? MenSize { get; set; }
        public WomenClothingSizeEnum? WomenSize { get; set; }
        public MenTrouserSizeEnum? MenTrouserSize { get; set; }
        public WomenTrouserSizeEnum? WomanTrouserSize { get; set; }
        public MenShoeSizeEnum? MenShoeSize { get; set; }
        public WomenShoeSizeEnum? WomenShoeSize { get; set; }
        public MenWatchSizeEnum? MenWatchSize { get; set; }
        public WomenWatchSizeEnum? WomenWatchSize { get; set; }
    }
}
