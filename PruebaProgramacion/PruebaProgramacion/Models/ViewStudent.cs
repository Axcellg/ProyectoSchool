using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaProgramacion.Models;

[Keyless]
public partial class ViewStudent
{
    public int StudentId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? HireDate { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public decimal? Grade { get; set; }
}
