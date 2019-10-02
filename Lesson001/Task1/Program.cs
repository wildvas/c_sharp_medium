using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Users users = new Users(
                new User[] {
                    new User(1, "User 1", 1000),
                    new User(2, "User 2", 2000),
                    new User(3, "User 3", 1000),
                    new User(4, "User 4", 3000),
                    new User(5, "User 5", 8000),
                });

            Console.WriteLine("Все пользователи системы");
            foreach (User su in users.GetUsers())
            {
                Console.WriteLine($"ID: {su.Id} / Name: {su.Name} / Salary: {su.Salary}");
            }
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("Введите имя пользователя для поиска: ");
            string s = Console.ReadLine();
            User user = users.GetUserByName(s);
            Console.WriteLine(user == null ? "Пользователь не найден" : $"ID: {user.Id} / Name: {user.Name} / Salary: {user.Salary}");
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("Введите идентификатор пользователя для поиска: ");
            int i = Convert.ToInt32(Console.ReadLine());
            user = users.GetUserById(i);
            Console.WriteLine(user == null ? "Пользователь не найден" : $"ID: {user.Id} / Name: {user.Name} / Salary: {user.Salary}");
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("Пользователи с зарплатой больше 2000");
            foreach (User su in users.GetUsersWhithSalaryMore(2000))
            {
                Console.WriteLine($"ID: {su.Id} / Name: {su.Name} / Salary: {su.Salary}");
            }
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("Пользователи с зарплатой меньше 2000");
            foreach (User su in users.GetUsersWhithSalaryLess(2000))
            {
                Console.WriteLine($"ID: {su.Id} / Name: {su.Name} / Salary: {su.Salary}");
            }
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("Пользователи с зарплатой больше 1000 и меньше 4000");
            foreach (User su in users.GetUsersBySalary(1000, 4000))
            {
                Console.WriteLine($"ID: {su.Id} / Name: {su.Name} / Salary: {su.Salary}");
            }
            Console.WriteLine("----------------------------------------------------------");

            Console.ReadKey();
        }
    }

    class User
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Salary { get; }

        public User(int id, string name, decimal salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }
    }

    class Users
    {
        private User[] _collection;

        public Users(User[] usersCollection)
        {
            _collection = usersCollection;
        }

        public User GetUserByName(string name)
        {
            User result = _collection.FirstOrDefault(u => u.Name == name);
            return result;
        }

        public User GetUserById(int id)
        {
            User result = _collection.FirstOrDefault(u => u.Id == id);
            return result;
        }

        public IReadOnlyCollection<User> GetUsers()
        {
            return _collection;
        }

        public User[] GetUsersWhithSalaryLess(decimal salary)
        {
            return _collection.Where(u => u.Salary < salary).ToArray();
        }

        public User[] GetUsersWhithSalaryMore(decimal salary)
        {
            return _collection.Where(u => u.Salary > salary).ToArray();
        }
        public User[] GetUsersBySalary(decimal salaryFrom, decimal salaryTo)
        {
            return _collection.Where(u => u.Salary > salaryFrom && u.Salary < salaryTo).ToArray();
        }
    }
}