using DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMaterialService : IGenericService<Material>
    {
        Task<Material> GetMaterialByMaterialCode(string code);
    }
}
