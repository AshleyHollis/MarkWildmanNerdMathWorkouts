using MarkWildmanNerdMathWorkouts.Application.Specifications.Base;
using MarkWildmanNerdMathWorkouts.Domain.Entities.Misc;

namespace MarkWildmanNerdMathWorkouts.Application.Specifications.Misc
{
    public class DocumentTypeFilterSpecification : HeroSpecification<DocumentType>
    {
        public DocumentTypeFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.Name.Contains(searchString) || p.Description.Contains(searchString);
            }
            else
            {
                Criteria = p => true;
            }
        }
    }
}