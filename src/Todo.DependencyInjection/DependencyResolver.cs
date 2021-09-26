using FluentMigrator.Runner.VersionTableInfo;
using Microsoft.Extensions.DependencyInjection;
using Todo.Domain.Handlers.Users;
using Todo.Domain.Repositories;
using Todo.FluentMigrations.DbMigrations;
using Todo.Infra.Contexts;
using Todo.Infra.Repositories;
using Todo.Infra.Transactions;

namespace Todo.DependencyInjection
{
    public class DependencyResolver
    {
        public void Resolver(IServiceCollection services)
        {
            services.AddDbContext<TodoDataContext, TodoDataContext>();
            services.AddTransient<IUow, Uow>();

            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<UserHandler, UserHandler>();

            services.AddTransient<IVersionTableMetaData, TableVersionMigration>();
        }
    }
}
