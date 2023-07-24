using System;
using System.Collections.Generic;

namespace CookingAppApi.Models;

public partial class Favorite
{
    public int FavoriteId { get; set; }

    public int? UserId { get; set; }

    public int? RecipeId { get; set; }

    public bool? IsFavorite { get; set; }

    public string? FavoriteDescription { get; set; }

    public virtual Recipe? Recipe { get; set; }

    public virtual User? User { get; set; }
}
