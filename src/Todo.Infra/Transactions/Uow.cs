using Todo.Domain.Repositories;
using Todo.Infra.Contexts;

namespace Todo.Infra.Transactions
{
    public class Uow : IUow
    {
        TodoDataContext _context;

        public Uow(TodoDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
