using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaProgramacion.Models;

[Keyless]
public partial class ViewCourse
{
    [Column("CourseID")]
    public int CourseId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public int Credits { get; set; }

    [StringLength(50)]
    public string Department { get; set; } = null!;
}
