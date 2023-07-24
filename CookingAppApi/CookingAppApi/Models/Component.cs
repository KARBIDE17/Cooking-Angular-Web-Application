using System;
using System.Collections.Generic;

namespace CookingAppApi.Models;

public partial class Component
{
    public int ComponentId { get; set; }

    public int? SectionId { get; set; }

    public int? IngredientId { get; set; }

    public int? Position { get; set; }

    public string? RawText { get; set; }

    public string? ExtraComment { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual Section? Section { get; set; }
}
