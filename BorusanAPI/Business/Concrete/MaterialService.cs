
using Business.Abstract;
using DataAccess.Abstract;
using DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MaterialService : IMaterialService
    {
        protected IMaterialRepository _materialRepository;
        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<Material> GetMaterialByMaterialCode(string code)
        {
            return await _materialRepository.GetMaterialByMetarialCode(code);
        }

        public async Task<Material> TCreate(Material material)
        {
            return await _materialRepository.Create(material);
        }

        public async Task TDelete(int id)
        {
            await _materialRepository.Delete(id);
        }

        public async Task<List<Material>> TGetAll()
        {
            return await _materialRepository.GetAll();
        }

        public async Task<Material> TGetById(int id)
        {
            return await _materialRepository.GetById(id);
        }

        public async Task<Material> TUpdate(Material material)
        {
            return await _materialRepository.Update(material);
        }
    }
}
