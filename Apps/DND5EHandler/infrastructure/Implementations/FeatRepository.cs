using infrastructure.Interfaces;
using infrastructure.Models.Feats;
using Npgsql;

namespace infrastructure.Implementations;

public class FeatRepository : IRepository<FeatModel>
{
    
    private readonly NpgsqlDataSource _dataSource;

    public FeatRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    
    
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