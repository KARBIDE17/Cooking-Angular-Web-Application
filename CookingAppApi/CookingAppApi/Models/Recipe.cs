using System;
using System.Collections.Generic;

namespace CookingAppApi.Models;

public partial class Recipe
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

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<Instruction> Instructions { get; set; } = new List<Instruction>();

    public virtual ICollection<Nutrition> Nutritions { get; set; } = new List<Nutrition>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
