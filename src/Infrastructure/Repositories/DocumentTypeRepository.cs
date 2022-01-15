using MarkWildmanNerdMathWorkouts.Application.Interfaces.Repositories;
using MarkWildmanNerdMathWorkouts.Domain.Entities.Misc;

namespace MarkWildmanNerdMathWorkouts.Infrastructure.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly IRepositoryAsync<DocumentType, int> _repository;

        public DocumentTypeRepository(IRepositoryAsync<DocumentType, int> repository)
        {
            _repository = repository;
        }
    }
}