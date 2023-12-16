using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaProgramacion.Models;

[Keyless]
public partial class ViewInstructor
{
    public int InstructorId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime? HireDate { get; set; }

    public int CourseId { get; set; }

    [StringLength(100)]
    public string Course { get; set; } = null!;
}
