using MarkWildmanNerdMathWorkouts.Application.Interfaces.Repositories;
using MarkWildmanNerdMathWorkouts.Domain.Entities.Catalog;

namespace MarkWildmanNerdMathWorkouts.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IRepositoryAsync<Brand, int> _repository;

        public BrandRepository(IRepositoryAsync<Brand, int> repository)
        {
            _repository = repository;
        }
    }
}