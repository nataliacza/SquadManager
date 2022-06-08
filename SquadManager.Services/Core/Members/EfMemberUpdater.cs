using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SquadManager.Database;
using SquadManager.Dtos.Members;
using SquadManager.Services.Interfaces.Member;

namespace SquadManager.Services.Core.Members;

public class EfMemberUpdater : IMemberUpdater
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _autoMapper;

    public EfMemberUpdater(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _autoMapper = mapper;
    }

    public async Task<SaveMemberDto> UpdateDetails(Guid id, SaveMemberDto memberDto)
    {
        var member = await _dbContext.Members
            .FirstOrDefaultAsync(x => x.Id == id);

        if (member == null)
        {
            return null!;
        }

        member.FirstName = memberDto.FirstName;
        member.LastName = memberDto.LastName;
        member.Email = memberDto.Email;
        member.Mobile = memberDto.Mobile;

        _dbContext.Members.Update(member);
        await _dbContext.SaveChangesAsync();

        var dto = _autoMapper.Map<SaveMemberDto>(member);

        return dto;
    }

    public async Task<UpdateMemberPropertyDto> UpdateProperty(
        Guid id, UpdateMemberPropertyDto propertyDto)
    {
        var property = await _dbContext.MemberProperties
            .FirstOrDefaultAsync(x => x.MemberId == id);

        if (property == null)
        {
            return null!;
        }

        property.RoleType = propertyDto.RoleType;
        property.Kpp = propertyDto.Kpp;
        property.KppDate = propertyDto.KppDate;
        property.KppDExpiration = propertyDto.KppDExpiration;
        property.MedicalExamination = propertyDto.MedicalExamination;
        property.MedicalExaminationDate = propertyDto.MedicalExaminationDate;
        property.MedicalExaminationExpiration = propertyDto.MedicalExaminationExpiration;
        property.BasicCourse = propertyDto.BasicCourse;
        property.BasicCourseDate = propertyDto.BasicCourseDate;
        property.GuideCourse = propertyDto.GuideCourse;
        property.GuideCourseDate = propertyDto.GuideCourseDate;
        property.InstructorCourse = propertyDto.InstructorCourse;
        property.InstructorCourseDate = propertyDto.InstructorCourseDate;
        property.ExaminerCourse = propertyDto.ExaminerCourse;
        property.ExaminerCourseDate = propertyDto.ExaminerCourseDate;
        property.CommanderCourse = propertyDto.CommanderCourse;
        property.CommanderCourseDate = propertyDto.CommanderCourseDate;
        property.HeightCourse = propertyDto.HeightCourse;
        property.HeightCourseDate = propertyDto.HeightCourseDate;
        property.HelicopterCourse = propertyDto.HelicopterCourse;
        property.HelicopterCourseDate = propertyDto.HelicopterCourseDate;

        var dto = _autoMapper.Map<UpdateMemberPropertyDto>(property);

        return dto;
    }
}
