using PhysiqueAnalyzerApi.Models;
namespace PhysiqueAnalyzerApi.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}