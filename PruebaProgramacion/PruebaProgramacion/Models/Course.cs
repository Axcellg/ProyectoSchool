using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaProgramacion.Models;

[Table("Course")]
public partial class Course
{
    [Key]
    [Column("CourseID")]
    public int CourseId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public int Credits { get; set; }

    [Column("DepartmentID")]
    public int DepartmentId { get; set; }

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

    [ForeignKey("DepartmentId")]
    [InverseProperty("Courses")]
    public virtual Department Department { get; set; } = null!;

    [InverseProperty("Course")]
    public virtual OnlineCourse? OnlineCourse { get; set; }

    [InverseProperty("Course")]
    public virtual OnsiteCourse? OnsiteCourse { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<StudentGrade> StudentGrades { get; } = new List<StudentGrade>();

    [ForeignKey("CourseId")]
    [InverseProperty("Courses")]
    public virtual ICollection<Person> People { get; } = new List<Person>();
}
