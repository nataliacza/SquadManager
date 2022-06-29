using SquadManager.Database.Models;

namespace SquadManager.Services.Common;

public class ResetDateFieldsForFalseValues
{
    public static void ResetDates(MemberProperty update, MemberProperty property)
    {
        if (update.Kpp == false)
        {
            property.KppDate = null;
            property.KppExpiration = null;
        }
        if (update.MedicalExamination == false)
        {
            property.MedicalExaminationDate = null;
            property.MedicalExaminationExpiration = null;
        }
        if (update.BasicCourse == false)
        {
            property.BasicCourseDate = null;
        }
        if (update.GuideCourse == false)
        {
            property.GuideCourseDate = null;
        }
        if (update.InstructorCourse == false)
        {
            property.InstructorCourseDate = null;
        }
        if (update.ExaminerCourse == false)
        {
            property.ExaminerCourseDate = null;
        }
        if (update.CommanderCourse == false)
        {
            property.CommanderCourseDate = null;
        }
        if (update.HeightCourse == false)
        {
            property.HeightCourseDate = null;
        }
        if (update.HelicopterCourse == false)
        {
            property.HelicopterCourseDate = null;
        }
    }
}
