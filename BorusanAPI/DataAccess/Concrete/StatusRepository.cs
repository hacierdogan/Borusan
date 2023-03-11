using DataAccess.Abstract;
using DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
    }
}
