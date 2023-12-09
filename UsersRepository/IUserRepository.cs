using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersRepository
{
    public interface IUserRepository : IRepository<User>
    {
        User? GetById(int id);
        User? GetByName(string name);
        User? GetByEmail(string email);
        
        IEnumerable<User> GetByCity(string city);
        IEnumerable<User> GetByGender(User.Gender gender);
    }
}
