using api.TransferModels.DndEntities;
using Domain.Models;

namespace api.Mappers.DndEntities;

public static class DndEntityMapper
{
    // Domain -> Simple Model
    public static DndEntitySimpleModel ToDndEntitySimpleModel(this DndEntity entity)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));
        return new DndEntitySimpleModel
        {
            Id = entity.Id,
            Name = entity.Name,
            IsPublic = entity.IsPublic,
            UsedRuleset = entity.UsedRuleset
        };
    }
    
    // Full DTO -> Simple Model
    public static DndEntitySimpleModel ToDndEntitySimpleModel(this DndEntityDto dto)
    {
        if (dto is null) throw new ArgumentNullException(nameof(dto));
        return new DndEntitySimpleModel
        {
            Id = dto.Id,
            Name = dto.Name,
            IsPublic = dto.IsPublic,
            UsedRuleset = dto.UsedRuleset
        };
    }
    
    // Simple Model -> Simple DTO
    public static DndEntitySimpleDto ToDndEntitySimpleDto(this DndEntitySimpleModel model)
    {
        if (model is null) throw new ArgumentNullException(nameof(model));
        return new DndEntitySimpleDto
        {
            Id = model.Id,
            Name = model.Name,
            IsPublic = model.IsPublic,
            UsedRuleset = model.UsedRuleset
        };
    }
    
    // Domain -> Simple DTO
    public static DndEntitySimpleDto ToDndEntitySimpleDto(this DndEntity entity)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));
        return new DndEntitySimpleDto
        {
            Id = entity.Id,
            Name = entity.Name,
            IsPublic = entity.IsPublic,
            UsedRuleset = entity.UsedRuleset
        };
    }
    
    // Domain -> Full DTO
    public static DndEntityDto ToDndEntityDto(this DndEntity entity)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));
        return new DndEntityDto
        {
            Id = entity.Id,
            Name = entity.Name,
            IsPublic = entity.IsPublic,
            IsOfficial = entity.IsOfficial,
            CreatedByUserId = entity.CreatedByUserId,
            CreatedAt = entity.CreatedAt,
            UsedRuleset = entity.UsedRuleset,
            Type = entity.Type
        };
    }
    
}