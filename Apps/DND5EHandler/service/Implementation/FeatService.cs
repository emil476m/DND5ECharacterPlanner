using infrastructure.Interfaces;
using infrastructure.Models;
using infrastructure.Models.Feats;
using infrastructure.Models.Miscellaneous;
using infrastructure.Models.Miscellaneous.Enums;
using service.Interfaces;

namespace service.Implementation;

public class FeatService : IService<FeatModel , FeatCreateModelDto>
{
    
    private readonly IRepository<FeatModel> _featRepository;

    public FeatService(IRepository<FeatModel> featRepository)
    {
        _featRepository = featRepository;
    }
    
    public Task<FeatModel> GetResult(Guid id)
    {
        return _featRepository.GetResult(id);
    }

    public Task<IEnumerable<DndEntitySimpleModel>> GetSimpleList()
    {
        return _featRepository.GetSimpleList();
    }

    public Task<IEnumerable<FeatModel>> GetDetailedList()
    {
        return _featRepository.GetDetailedList();
    }

    public Task<bool> Delete(Guid id)
    {
        return _featRepository.Delete(id);
    }

    public Task<FeatModel> Create(FeatCreateModelDto item)
    {
        var feat = new FeatModel
        {
            Id = Guid.NewGuid(),
            Name = item.Name,
            IsPublic = item.IsPublic,
            IsOfficial = false,
            CreatedAt = DateTime.UtcNow,
            UsedRuleset = item.UsedRuleset,
            Type = EntityType.Feat,
            Effect = item.Effect,
            EffectChoices = item.EffectChoices,
            AbilityScoreIncreaseChoices = item.AbilityScoreIncreaseChoices,
            AbilityScoreIncreases = item.AbilityScoreIncreases,
        };
        
        return _featRepository.Create(feat);
    }

    public Task<FeatModel> Update(Guid id, FeatCreateModelDto item)
    {
        
        var feat = new FeatModel
        {
            Id = id,
            Name = item.Name,
            IsPublic = item.IsPublic,
            IsOfficial = false,
            CreatedAt = DateTime.UtcNow,
            UsedRuleset = item.UsedRuleset,
            Type = EntityType.Feat,
            Effect = item.Effect,
            EffectChoices = item.EffectChoices,
            AbilityScoreIncreaseChoices = item.AbilityScoreIncreaseChoices,
            AbilityScoreIncreases = item.AbilityScoreIncreases,
        };
        
        return _featRepository.Update(id, feat);
    }
}