using System;
using System.Linq.Expressions;
using Todo.Domain.Models.Users;

namespace Todo.Domain.Queries.Users
{
    public class UserQuery
    {
        public static Expression<Func<User, bool>> GetByUserName(string userName)
        {
            return x => x.Login.UserName == userName;
        }
    }
}
