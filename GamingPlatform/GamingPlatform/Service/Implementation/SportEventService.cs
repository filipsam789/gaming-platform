using GamingPlatform.Domain.SportEventDomain;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class SportEventService : ISportEventService
    {
        private readonly IRepository<Event> _repository;

        public SportEventService(IRepository<Event> repository)
        {
            _repository = repository;
        }

        public List<Event> GetAll()
        {
            return _repository.GetAll().ToList();
        }
    }
}
