using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam1And2_Web2_IUSR.Models;

public partial class product
{
    [Key] public int Id { get; set; }

    [StringLength(100)] [Unicode(false)] public string? Name { get; set; }

    public double? Price { get; set; }

    [StringLength(100)] [Unicode(false)] public string? ninStock { get; set; }

    public string? Description { get; set; }

    [InverseProperty("product")] public virtual ICollection<order> orders { get; set; } = new List<order>();
}