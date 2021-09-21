using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Models.Users;
using Todo.Domain.Queries.Users;
using Todo.Domain.Repositories;
using Todo.Infra.Contexts;

namespace Todo.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        TodoDataContext _context;

        public UserRepository(TodoDataContext context)
        {
            _context = context;
        }

        public IList<User> GetAll()
        {
            return _context.Users.AsNoTracking().ToList();
        }

        public User GetByUserName(string userName)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(UserQuery.GetByUserName(userName));
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
