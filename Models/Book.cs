using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirst.Models;

public partial class Book
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string? Title { get; set; }

    public int? PublishedYear { get; set; }

    public int? AuthorId { get; set; }

    [ForeignKey("AuthorId")]
    [InverseProperty("Books")]
    public virtual Author? Author { get; set; }

    [InverseProperty("Book")]
    public virtual ICollection<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();
}
