using infrastructure.Models.Feats;
using service.Interfaces;

namespace service.Implementation;

public class FeatService : IService<FeatModel>
{
    public Task<FeatModel> GetResult(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<FeatModel> Create(FeatModel item)
    {
        throw new NotImplementedException();
    }

    public Task<FeatModel> Update(Guid id, FeatModel item)
    {
        throw new NotImplementedException();
    }
}