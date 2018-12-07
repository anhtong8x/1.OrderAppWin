using TN.Infrastructure.Interfaces;
using TN.Domain.Model;

namespace TN.Infrastructure.Repositories
{
    public class TableStatusRepository : EntityBaseRepository<TableStatus>, ITableStatusRespository
	{
        public TableStatusRepository(ApplicationContext context) : base(context)
        {
        }

    }
}
