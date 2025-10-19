using api.TransferModels.DndEntities;
using Core.Models;

namespace api.Mappers;

public static class DndEntityMapper
{
    // Core -> Simple Model
    public static DndEntitySimpleModel ToDndEntitySimpleModel(this DndEntityModel entityModel)
    {
        if (entityModel is null) throw new ArgumentNullException(nameof(entityModel));
        return new DndEntitySimpleModel
        {
            Id = entityModel.Id,
            Name = entityModel.Name,
            IsPublic = entityModel.IsPublic,
            UsedRuleset = entityModel.UsedRuleset
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

    // Core -> Simple DTO
    public static DndEntitySimpleDto ToDndEntitySimpleDto(this DndEntityModel entityModel)
    {
        if (entityModel is null) throw new ArgumentNullException(nameof(entityModel));
        return new DndEntitySimpleDto
        {
            Id = entityModel.Id,
            Name = entityModel.Name,
            IsPublic = entityModel.IsPublic,
            UsedRuleset = entityModel.UsedRuleset
        };
    }

    // Core -> Full DTO
    public static DndEntityDto ToDndEntityDto(this DndEntityModel entityModel)
    {
        if (entityModel is null) throw new ArgumentNullException(nameof(entityModel));
        return new DndEntityDto
        {
            Id = entityModel.Id,
            Name = entityModel.Name,
            IsPublic = entityModel.IsPublic,
            IsOfficial = entityModel.IsOfficial,
            CreatedByUserId = entityModel.CreatedByUserId,
            CreatedAt = entityModel.CreatedAt,
            UsedRuleset = entityModel.UsedRuleset,
            Type = entityModel.Type
        };
    }
}