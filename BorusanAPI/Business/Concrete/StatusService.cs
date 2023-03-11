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
    public class StatusService : IStatusService
    {
        protected IStatusRepository _statusRepository;
        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<Status> TCreate(Status status)
        {
            return await _statusRepository.Create(status);
        }

        public async Task TDelete(int id)
        {
            await _statusRepository.Delete(id);
        }

        public async Task<List<Status>> TGetAll()
        {
            return await _statusRepository.GetAll();
        }

        public async Task<Status> TGetById(int id)
        {
            return await _statusRepository.GetById(id);
        }

        public async Task<Status> TUpdate(Status status)
        {
            return await _statusRepository.Update(status);
        }
    }
}
