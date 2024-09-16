using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamingPlatform.Domain.SportEventDomain;
using Repository;
using Service.Interface;

namespace IntegratedSystems.Web.Controllers
{
    public class SportEventController : Controller
    {
        private readonly ISportEventService _sportEventService;

        public SportEventController(ISportEventService sportEventService)
        {
            _sportEventService = sportEventService;
        }

        // GET: SportEvent
        public IActionResult Index()
        {
            var sportEvents = _sportEventService.GetAll();
            return View(sportEvents);
        }
    }
}
