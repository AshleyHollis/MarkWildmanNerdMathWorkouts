using System.Threading.Tasks;

namespace MarkWildmanNerdMathWorkouts.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<bool> IsBrandUsed(int brandId);
    }
}