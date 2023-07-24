using System;
using System.Collections.Generic;

namespace CookingAppApi.Models;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public int? Id { get; set; }

    public int? RecipeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Component> Components { get; set; } = new List<Component>();

    public virtual Recipe? Recipe { get; set; }
}
