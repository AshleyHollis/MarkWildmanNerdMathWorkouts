using MarkWildmanNerdMathWorkouts.Application.Requests;

namespace MarkWildmanNerdMathWorkouts.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}