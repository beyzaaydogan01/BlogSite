
using Core.Entities;
using Core.Responses;

namespace Core.Services;

public interface IService<TEntity, TId, TResponse, TRequest, TUpdateRequest>
    where TEntity : Entity<TId>, new()
{
    ReturnModel<TResponse> Add(TRequest create);
    ReturnModel<TResponse> Update(TUpdateRequest update);
    ReturnModel<TResponse> GetById(TId id);
    ReturnModel<List<TResponse>> GetAll();
    ReturnModel<TResponse> Delete(TId id);
}
