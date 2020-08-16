using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garages_Recruit_1271.Models
{
    public interface IUserRepository
    {
        User GetUser(int id);

        IEnumerable<User> GetAllUsers();

        User AddUser(User user);

        User Update(User userChange);

        User Delete(int id);
    }
}
