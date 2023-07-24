using System;
using System.Collections.Generic;

namespace CookingAppApi.Models;

public partial class Nutrition
{
    public int NutritionId { get; set; }

    public int? RecipeId { get; set; }

    public int? Carbohydrates { get; set; }

    public int? Fiber { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? Protein { get; set; }

    public int? Fat { get; set; }

    public int? Calories { get; set; }

    public int? Sugar { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
