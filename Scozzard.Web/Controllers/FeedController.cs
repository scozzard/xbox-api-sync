using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Scozzard.Model;
using Scozzard.Service;
using Scozzard.Web.ViewModels;

namespace Scozzard.Web.Controllers
{
    public class FeedController : Controller
    {
        private readonly IXboxUserService xboxUserService;

        public FeedController(IXboxUserService xboxUserService)
        {
            this.xboxUserService = xboxUserService;
        }

        // GET: Home
        public ActionResult Index(string category = null)
        {
            IEnumerable<ActivityViewModel> activityViewModels;

            var xboxUser = xboxUserService.GetXboxUser(1);
            var userActivities = xboxUserService.GetXboxUser(1).Activities;
            var friendsActivities = xboxUserService.GetXboxUser(1).Friends.SelectMany(a => a.Activities);

            var allActivities =  userActivities.Union(friendsActivities);


            activityViewModels = Mapper.Map<IEnumerable<Activity>, IEnumerable<ActivityViewModel>>(allActivities.OrderByDescending(a => a.StartTime));
            return View(activityViewModels);
        }
    }
}