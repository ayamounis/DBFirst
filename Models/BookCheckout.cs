using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirst.Models;

public partial class BookCheckout
{
    [Key]
    public int Id { get; set; }

    public int? BookId { get; set; }

    public int? MemberId { get; set; }

    public DateOnly? CheckoutDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("BookCheckouts")]
    public virtual Book? Book { get; set; }

    [ForeignKey("MemberId")]
    [InverseProperty("BookCheckouts")]
    public virtual Member? Member { get; set; }
}
