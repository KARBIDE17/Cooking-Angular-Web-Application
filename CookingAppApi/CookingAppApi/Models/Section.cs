using System;
using System.Collections.Generic;

namespace CookingAppApi.Models;

public partial class Section
{
    public int SectionId { get; set; }

    public int? RecipeId { get; set; }

    public string? Name { get; set; }

    public int? Position { get; set; }

    public virtual ICollection<Component> Components { get; set; } = new List<Component>();

    public virtual Recipe? Recipe { get; set; }
}
