using System;
using System.Collections.Generic;

namespace OF_Project.Models;

public partial class Food
{
    public int TypeId { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public string? Img { get; set; }

    public string? Detail { get; set; }
}
