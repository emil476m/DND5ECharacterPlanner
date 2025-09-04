using infrastructure.Interfaces;
using infrastructure.Models.Feats;
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

    public Task<bool> Delete(Guid id)
    {
        return _featRepository.Delete(id);
    }

    public Task<FeatModel> Create(FeatCreateModelDto item)
    {
        throw new NotImplementedException();
    }

    public Task<FeatModel> Update(Guid id, FeatCreateModelDto item)
    {
        throw new NotImplementedException();
    }
}