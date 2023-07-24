using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
namespace CookingAppApi.Models;


public partial class Instruction
{
    public int InstructionId { get; set; }

    public int? RecipeId { get; set; }

    public int? Position { get; set; }

    public string? DisplayText { get; set; }

    public int? StartTime { get; set; }

    public int? EndTime { get; set; }

    public string? Appliance { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
