using System.Linq;
using PhysiqueAnalyzerApi.Models;
using PhysiqueAnalyzerApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace PhysiqueAnalyzerApi.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context) { _context = context; }
        public User GetByUsername(string username)
        {
            return _context.Users.Include(u => u.WorkoutHistories).SingleOrDefault(u => u.Username == username);
        }
        public User Create(string username, string password)
        {
            if (_context.Users.Any(x => x.Username == username))
                return null;
            using var hmac = new HMACSHA512();
            var user = new User
            {
                Username = username,
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        public bool CheckPassword(User user, string password)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(user.PasswordHash);
        }
    }
}