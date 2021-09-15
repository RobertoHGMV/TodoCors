using System.Collections.Generic;
using Todo.Domain.Models.Users;

namespace Todo.Domain.Repositories
{
    public interface IUserRepository
    {
        IList<User> GetAll();
        User GetByUserName(string userName);
        void Add(User user);
        void Update(User user);
        void Remove(User user);
    }
}
