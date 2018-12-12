using System;
using System.Collections.Generic;
using System.Text;
using TN.Domain.Model.Manager;
using TN.Infrastructure.Interfaces.Manager;

namespace TN.Infrastructure.Repositories.Manager
{
    public class BillDetailRepository : EntityBaseRepository<BillDetail>, IBillDetailRepository
    {
        public BillDetailRepository(ApplicationContext context) : base(context)
        {
        }
    }   
}
