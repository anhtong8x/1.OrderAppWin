using System;
using System.Collections.Generic;
using System.Text;
using TN.Domain.Seedwork;
using TN.Domain.Model;
using System.Threading.Tasks;
namespace TN.Infrastructure.Interfaces
{
    public interface ILogRepository : IEntityBaseRepository<Log>
    {
    }
}
