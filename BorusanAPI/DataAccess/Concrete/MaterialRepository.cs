using Microsoft.EntityFrameworkCore;
using DataAccess.Abstract;
using DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class MaterialRepository : GenericRepository<Material>, IMaterialRepository
    {
        public async Task<Material> GetMaterialByMetarialCode(string code)
        {
            using (var db = new DataContext())
            {
                return await db.Materials.FirstOrDefaultAsync(w => w.MetarialCode.ToUpper() == code.ToUpper());
            }
        }
    }
}
