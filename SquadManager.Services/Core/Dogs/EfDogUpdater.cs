﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SquadManager.Database;
using SquadManager.Database.Models;
using SquadManager.Dtos.Dogs;
using SquadManager.Services.Interfaces.Dog;

namespace SquadManager.Services.Core.Dogs;

public class EfDogUpdater : IDogUpdater
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public EfDogUpdater(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<DogDto> UpdateDog(Guid id, SaveDogDto updateDto)
    {
        var dog = await _dbContext.Dogs
            .FirstOrDefaultAsync(x => x.Id == id);

        if (dog == null)
        {
            return null!;
        }

        var member = await _dbContext.Members
            .FirstOrDefaultAsync(x => x.Id == updateDto.OwnerId);

        //TODO: cover exception
        if (member == null)
        {
            return null!;
        }

        var contextDto = _mapper.Map(updateDto, dog);

        _dbContext.Update(contextDto);
        await _dbContext.SaveChangesAsync();

        var dto = _mapper.Map<DogDto>(dog);

        return dto;
    }
}