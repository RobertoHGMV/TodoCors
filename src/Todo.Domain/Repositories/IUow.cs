namespace Todo.Domain.Repositories
{
    public interface IUow
    {
        void Commit();
    }
}
