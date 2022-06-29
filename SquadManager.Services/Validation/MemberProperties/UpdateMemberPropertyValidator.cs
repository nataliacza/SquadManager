using FluentValidation;
using SquadManager.Dtos.MemberProperty;

namespace SquadManager.Services.Validation.MemberProperties;

public class UpdateMemberPropertyValidator : AbstractValidator<UpdateMemberPropertyDto>
{
    public UpdateMemberPropertyValidator()
    {
        RuleFor(x => x.KppDate)
            .NotEmpty().When(x => x.Kpp == true)
            .LessThanOrEqualTo(DateTime.UtcNow);
        RuleFor(x => x.KppExpiration)
            .NotEmpty().When(x => x.Kpp == true)
            .GreaterThan(DateTime.UtcNow);

        RuleFor(x => x.MedicalExaminationDate)
            .NotEmpty().When(x => x.MedicalExamination == true)
            .LessThanOrEqualTo(DateTime.UtcNow);
        RuleFor(x => x.MedicalExaminationExpiration)
            .NotEmpty().When(x => x.MedicalExamination == true)
            .GreaterThan(DateTime.UtcNow);

        RuleFor(x => x.BasicCourseDate)
            .NotEmpty().When(x => x.BasicCourse == true)
            .LessThanOrEqualTo(DateTime.UtcNow);

        RuleFor(x => x.GuideCourseDate)
            .NotEmpty().When(x => x.GuideCourse == true)
            .LessThanOrEqualTo(DateTime.UtcNow);

        RuleFor(x => x.InstructorCourseDate)
            .NotEmpty().When(x => x.InstructorCourse == true)
            .LessThanOrEqualTo(DateTime.UtcNow);

        RuleFor(x => x.ExaminerCourseDate)
            .NotEmpty().When(x => x.ExaminerCourse == true)
            .LessThanOrEqualTo(DateTime.UtcNow);

        RuleFor(x => x.CommanderCourseDate)
            .NotEmpty().When(x => x.CommanderCourse == true)
            .LessThanOrEqualTo(DateTime.UtcNow);

        RuleFor(x => x.HeightCourseDate)
            .NotEmpty().When(x => x.HeightCourse == true)
            .LessThanOrEqualTo(DateTime.UtcNow);

        RuleFor(x => x.HelicopterCourseDate)
            .NotEmpty().When(x => x.HelicopterCourse == true)
            .LessThanOrEqualTo(DateTime.UtcNow);
    }
}
