using System.Security.Cryptography.X509Certificates;

namespace UsersRepository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository repository = new UserMemoryRepository();

            User[] users = new User[]
                {
                    new(0, "Ivan Ivanov", User.Gender.Male, "Kaliningrad", null, "+73874293487"),
                    new(1, "Galina Petrovna", User.Gender.Female, "Cheboksary", null, null),
                    new(2, "Joseph Smith", User.Gender.Male, "New-York", null, "+12345678921"),
                    new(3, "Vasiliy Pupkin", User.Gender.Male, "Kaliningrad", "vasya@yandex.ru", null)
                };

            foreach(var user in users)
            {
                repository.Add(user);
            }

            var items = repository.Items;
            Console.WriteLine("Items:\n\t" + String.Join("\n\t", items));
            var firstUser = repository.GetById(0);
            if(firstUser != null) 
                firstUser.Phone = "+71234567890";

            var males = repository.GetByGender(User.Gender.Male);
            Console.WriteLine("Males:\n\t" + String.Join("\n\t", males));


            var usersToRemove = repository.GetByCity("Cheboksary").ToList();
            foreach(var user in usersToRemove)
            {
                repository.Delete(user);
            }

            items = repository.Items;
            Console.WriteLine("Items after removing and modifying:\n\t" + String.Join("\n\t", items));

        }
    }
}