using ePizzaHut.Entity;
using System.Threading.Tasks;

namespace ePizzaHut.Services.Interfaces
{
    public interface IAuthentationService
    {
        bool CreateUser(User user, string password);
        Task<bool> SignOut();
        User AuthenticateUser(string userName, string password);
        User GetUser(string userName);
    }
}
