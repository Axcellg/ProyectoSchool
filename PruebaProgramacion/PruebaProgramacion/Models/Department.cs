using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaProgramacion.Models;

public partial class Department
{
    [Key]
    [Column("DepartmentID")]
    public int DepartmentId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Budget { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    public int? Administrator { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifyDate { get; set; }

    public int CreationUser { get; set; }

    public int? UserMod { get; set; }

    public int? UserDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletedDate { get; set; }

    public bool Deleted { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<Course> Courses { get; } = new List<Course>();
}
