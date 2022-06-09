using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SquadManager.Database;
using SquadManager.Database.Models;
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

    public async Task<MemberDetailsDto> UpdateDetails(Guid id, SaveMemberDto updateDto)
    {
        var member = await _dbContext.Members
            .FirstOrDefaultAsync(x => x.Id == id);

        if (member == null)
        {
            return null!;
        }

        var update = _autoMapper.Map(updateDto, member);

        _dbContext.Members.Update(member);
        await _dbContext.SaveChangesAsync();

        var dto = _autoMapper.Map<MemberDetailsDto>(member);

        return dto;
    }

    public async Task<MemberPropertyDto> UpdateProperty(Guid id, UpdateMemberPropertyDto updateDto)
    {
        var property = await _dbContext.MemberProperties
            .FirstOrDefaultAsync(x => x.MemberId == id);

        if (property == null)
        {
            return null!;
        }
        
        var update = _autoMapper.Map(updateDto, property);

        ResetDatesForFields(update, property);

        _dbContext.MemberProperties.Update(property);
        await _dbContext.SaveChangesAsync();

        var dto = _autoMapper.Map<MemberPropertyDto>(property);

        return dto;
    }

    private static void ResetDatesForFields(MemberProperty update, MemberProperty property)
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
