using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersRepository
{
    public class UserMemoryRepository : MemoryRepository<User>, IUserRepository
    {
        public IEnumerable<User> GetByCity(string city)
        {
            return _items.Where(user => user.CityName == city);
        }

        public User? GetByEmail(string email)
        {
            return _items.Where(user => user.CityName == email).FirstOrDefault();
        }

        public IEnumerable<User> GetByGender(User.Gender gender)
        {
            return _items.Where(user => user.UserGender == gender);

        }

        public User? GetById(int id)
        {
            return _items.Where(user => user.Id == id).FirstOrDefault();

        }

        public User? GetByName(string name)
        {
            return _items.Where(user => user.Name == name).FirstOrDefault();
        }
    }
}
