namespace CookingAppApi.Models
{
    public class FavoriteRecipe
    {

        public int RecipeId { get; set; }

        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Yields { get; set; }

        public int? NumServings { get; set; }

        public string? ThumbnailUrl { get; set; }

        public string? ThumbnailAltText { get; set; }

        public string? OriginalVideoUrl { get; set; }

        public int? CookTimeMinutes { get; set; }

        public int? PrepTimeMinutes { get; set; }

        public int? TotalTimeMinutes { get; set; }

        public string? SeoPath { get; set; }

        public string? SeoTitle { get; set; }

        public string? TotalTimeTier { get; set; }

        public int FavoriteId { get; set; }

        public int UserId { get; set; }

        public bool? IsFavorite { get; set; }

        public string? FavoriteDescription { get; set; }
    }


}
