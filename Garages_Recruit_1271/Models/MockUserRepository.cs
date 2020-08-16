using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garages_Recruit_1271.Models
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> _userList;

        public MockUserRepository()
        {
            _userList = new List<User>()
            {
                new User(){Id = 1,Name = "oron", Password = "Tt123456", Address ="fffff" , Mail= "ooo@gmail.com", Phone = 99999,Status = Status.Disable },
                 new User(){Id = 2,Name = "ffff", Password = "sssss", Address ="444444" , Mail= "oooee@gmail.com", Phone = 22222, Status = Status.Active }
            };
        }

        public User AddUser(User user)
        {
            user.Id = _userList.Max(e => e.Id) + 1;
            _userList.Add(user);
            return user;
        }

        public User Delete(int id)
        {
            User _user = _userList.FirstOrDefault(e => e.Id == id);
            if (_user != null)
            {
                _userList.Remove(_user);
            }
            return _user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userList;
        }

        public User GetUser(int id)
        {
            return _userList.FirstOrDefault(e => e.Id == id);
        }

        public User Update(User userChange)
        {
            User _user = _userList.FirstOrDefault(e => e.Id == userChange.Id);
            if (_user != null)
            {
                _user.Name = userChange.Name;
                _user.Password = userChange.Password;
                _user.Mail = userChange.Mail;
                _user.Address = userChange.Address;
                _user.Status = userChange.Status;
            }
            return _user;
        }
    }
}
