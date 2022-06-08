using SquadManager.Database.Enums;
using System.ComponentModel.DataAnnotations;

namespace SquadManager.Dtos.Members;

public class UpdateMemberPropertyDto
{
    [EnumDataType(typeof(RoleType))]
    public RoleType RoleType { get; set; }

    public bool? Kpp { get; set; }
    [RequiredIf("Kpp", "true")]
    public DateTime? KppDate { get; set; }
    [RequiredIf("Kpp", "true")]
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

public class RequiredIfAttribute : ValidationAttribute
{
    RequiredAttribute _innerAttribute = new RequiredAttribute();
    public string _dependentProperty { get; set; }
    public object _targetValue { get; set; }

    public RequiredIfAttribute(string dependentProperty, object targetValue)
    {
        this._dependentProperty = dependentProperty;
        this._targetValue = targetValue;
    }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var field = validationContext.ObjectType.GetProperty(_dependentProperty);
        if (field != null)
        {
            var dependentValue = field.GetValue(validationContext.ObjectInstance, null);
            if ((dependentValue == null && _targetValue == null) || (dependentValue.Equals(_targetValue)))
            {
                if (!_innerAttribute.IsValid(value))
                {
                    string name = validationContext.DisplayName;
                    string specificErrorMessage = ErrorMessage;
                    if (specificErrorMessage.Length < 1)
                        specificErrorMessage = $"{name} is required.";

                    return new ValidationResult(specificErrorMessage, new[] { validationContext.MemberName });
                }
            }
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult(FormatErrorMessage(_dependentProperty));
        }
    }
}
