using SquadManager.Database.Enums;

namespace SquadManager.Dtos.Members;

public class MemberPropertyDto
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }

    public RoleType RoleType { get; set; }

    public bool? Kpp { get; set; }
    public DateTime? KppDate { get; set; }
    public DateTime? KppDExpiration { get; set; }

    public bool? MedicalExamination { get; set; }
    public DateTime? MedicalExaminationDate { get; set; }
    public DateTime? MedicalExaminationExpiration { get; set; }

    public bool? BasicCourse { get; set; }
    public DateTime? BasicCourseDate { get; set; }
    public bool? GuideCourse { get; set; }
    public DateTime? GuideCourseDate { get; set; }
    public bool? InstructorCourse { get; set; }
    public DateTime? InstructorCourseDate { get; set; }
    public bool? ExaminerCourse { get; set; }
    public DateTime? ExaminerCourseDate { get; set; }
    public bool? CommanderCourse { get; set; }
    public DateTime? CommanderCourseDate { get; set; }
    public bool? HeightCourse { get; set; }
    public DateTime? HeightCourseDate { get; set; }
    public bool? HelicopterCourse { get; set; }
    public DateTime? HelicopterCourseDate { get; set; }
}
