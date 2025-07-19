using PhysiqueAnalyzerApi.Models;

namespace PhysiqueAnalyzerApi.Services
{
    public interface IUserService
    {
        User GetByUsername(string username);
        User Create(string username, string password);
        bool CheckPassword(User user, string password);
    }
}