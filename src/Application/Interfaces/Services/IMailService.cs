using MarkWildmanNerdMathWorkouts.Application.Requests.Mail;
using System.Threading.Tasks;

namespace MarkWildmanNerdMathWorkouts.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}