using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirst.Models;

public partial class Member
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string? FullName { get; set; }

    [InverseProperty("Member")]
    public virtual ICollection<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();
}
