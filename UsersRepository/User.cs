using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersRepository
{
    public class User
    {
        public enum Gender
        {
            Male,
            Female
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
        }

        public string CityName
        {
            get;
            set;
        }

        public string? Email
        {
            get;
            set;
        }

        public string? Phone
        {
            get;
            set;
        }

        public Gender UserGender
        {
            get;
        }
 

        public User(int id, string name, Gender gender, string cityName, string? email = null, string? phone = null)
        {
            Id = id;
            Name = name;
            Email = email;
            UserGender = gender;
            Phone = phone;
            CityName = cityName;
        }

        public override string ToString()
        {
            return $"{Name} from {CityName}, {Email} {Phone}";
        }
    }
}
