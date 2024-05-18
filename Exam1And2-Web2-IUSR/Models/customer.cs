using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam1And2_Web2_IUSR.Models;

public partial class customer
{
    [Key] public int Id { get; set; }

    [StringLength(100)] [Unicode(false)] public string Fname { get; set; } = null!;

    [StringLength(100)] [Unicode(false)] public string Lname { get; set; } = null!;

    [StringLength(100)] [Unicode(false)] public string? Father { get; set; }

    public int? PostalCode { get; set; }

    [StringLength(100)] [Unicode(false)] public string? Email { get; set; }

    [PhoneNumberValidationAttribute]
    [StringLength(100)]
    [Unicode(false)]
    public string? phoneNumber { get; set; }

    [InverseProperty("customer")] public virtual ICollection<order> orders { get; set; } = new List<order>();
}

// Phone number validation attribute for customer phoneNumber
class PhoneNumberValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        string phone = (string)value;

        if (phone == null)
        {
            return new ValidationResult("Phone number is required");
        }

        if (phone[3] != '-')
        {
            return new ValidationResult("Phone number is not valid must be like 123-");
        }

        return ValidationResult.Success;
    }
}