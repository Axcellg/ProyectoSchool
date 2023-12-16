using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PruebaProgramacion.Models;

public partial class Student
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? EnrollmentDate { get; set; }

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
}
