using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Scozzard.Model;
using Scozzard.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Scozzard.Service.Interfaces;

namespace Scozzard.Web.Controllers
{
    public class FeedController : Controller
    {
        private readonly IXboxUserService xboxUserService;
        private readonly IUserService userService;

        public FeedController(IXboxUserService xboxUserService, IUserService userService)
        {
            this.xboxUserService = xboxUserService;
            this.userService = userService;
        }

        // GET: Home
        [Authorize]
        public ActionResult Index(string category = null)
        {
            var userId = int.Parse(HttpContext.User.Identity.GetUserId());
            var user = userService.GetUser(userId);

            IEnumerable<ActivityViewModel> activityViewModels;

            var xboxUser = xboxUserService.GetXboxUser(user.XboxUserID);
            var userActivities = xboxUser.Activities;
            var friendsActivities = xboxUser.Friends.SelectMany(a => a.Activities);

            var allActivities =  userActivities.Union(friendsActivities);


            activityViewModels = Mapper.Map<IEnumerable<Activity>, IEnumerable<ActivityViewModel>>(allActivities.OrderByDescending(a => a.Date));
            return View(activityViewModels);
        }
    }
}