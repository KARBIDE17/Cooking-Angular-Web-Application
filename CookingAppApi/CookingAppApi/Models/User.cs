using System;
using System.Collections.Generic;

namespace CookingAppApi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }

    public string? UserEmail { get; set; }

    public string? UserPhone { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
