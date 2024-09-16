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
        private readonly ISportEventRepository<Event> _sportEventRepository;

        public SportEventService(ISportEventRepository<Event> sportEventRepository)
        {
            _sportEventRepository = sportEventRepository;
        }

        public List<Event> GetAll()
        {
            return _sportEventRepository.GetAll().ToList();
        }
    }
}
