using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam1And2_Web2_IUSR.Models;

public partial class order
{
    [Key] public int Id { get; set; }

    public int customerId { get; set; }

    public int productId { get; set; }

    public double sellprice { get; set; }

    [ForeignKey("customerId")]
    [InverseProperty("orders")]
    public virtual customer customer { get; set; } = null!;

    [ForeignKey("productId")]
    [InverseProperty("orders")]
    public virtual product product { get; set; } = null!;
}