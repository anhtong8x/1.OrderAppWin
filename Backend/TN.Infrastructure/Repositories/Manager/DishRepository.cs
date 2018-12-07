using TN.Infrastructure.Interfaces;
using TN.Domain.Model;

namespace TN.Infrastructure.Repositories
{
    public class DishRepository : EntityBaseRepository<Dish>, IDishRepository
	{
        public DishRepository(ApplicationContext context) : base(context)
        {
        }

    }
}
