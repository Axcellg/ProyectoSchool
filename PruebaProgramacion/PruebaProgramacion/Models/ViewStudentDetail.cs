using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaProgramacion.Models;

[Keyless]
public partial class ViewStudentDetail
{
    public int Id { get; set; }

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? EnrollmentDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? CreationDate { get; set; }
}
