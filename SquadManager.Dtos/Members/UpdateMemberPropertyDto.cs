using SquadManager.Dtos.Validation;
using System.ComponentModel.DataAnnotations;

namespace SquadManager.Dtos.Members;

public class UpdateMemberPropertyDto
{
    public bool? Kpp { get; set; }
    [RequiredIf(nameof(Kpp), true)]
    [DataType(DataType.Date)]
    [NotFutureDate]

    public DateTime? KppDate { get; set; }
    [RequiredIf(nameof(Kpp), true)]
    [DataType(DataType.Date)]
    public DateTime? KppExpiration { get; set; }

    public bool? MedicalExamination { get; set; }
    [RequiredIf(nameof(MedicalExamination), true)]
    [DataType(DataType.Date)]
    [NotFutureDate]
    public DateTime? MedicalExaminationDate { get; set; }
    [RequiredIf(nameof(MedicalExamination), true)]
    [DataType(DataType.Date)]
    public DateTime? MedicalExaminationExpiration { get; set; }

    public bool? BasicCourse { get; set; }
    [RequiredIf(nameof(BasicCourse), true)]
    [DataType(DataType.Date)]
    [NotFutureDate]
    public DateTime? BasicCourseDate { get; set; }

    public bool? GuideCourse { get; set; }
    [RequiredIf(nameof(GuideCourse), true)]
    [DataType(DataType.Date)]
    [NotFutureDate]
    public DateTime? GuideCourseDate { get; set; }

    public bool? InstructorCourse { get; set; }
    [RequiredIf(nameof(InstructorCourse), true)]
    [DataType(DataType.Date)]
    [NotFutureDate]
    public DateTime? InstructorCourseDate { get; set; }

    public bool? ExaminerCourse { get; set; }
    [RequiredIf(nameof(ExaminerCourse), true)]
    [DataType(DataType.Date)]
    [NotFutureDate]
    public DateTime? ExaminerCourseDate { get; set; }

    public bool? CommanderCourse { get; set; }
    [RequiredIf(nameof(CommanderCourse), true)]
    [DataType(DataType.Date)]
    [NotFutureDate]
    public DateTime? CommanderCourseDate { get; set; }

    public bool? HeightCourse { get; set; }
    [RequiredIf(nameof(HeightCourse), true)]
    [DataType(DataType.Date)]
    [NotFutureDate]
    public DateTime? HeightCourseDate { get; set; }

    public bool? HelicopterCourse { get; set; }
    [RequiredIf(nameof(HelicopterCourse), true)]
    [DataType(DataType.Date)]
    [NotFutureDate]
    public DateTime? HelicopterCourseDate { get; set; }
}
