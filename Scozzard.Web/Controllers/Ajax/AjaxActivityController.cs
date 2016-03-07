using Microsoft.AspNet.Identity;
using Scozzard.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scozzard.Web.Controllers.Ajax
{
    public class AjaxActivityController : Controller
    {
        private readonly IXboxUserService xboxUserService;
        private readonly IActivityService activityService;
        private readonly IUserService userService;

        public AjaxActivityController(IXboxUserService xboxUserService, IActivityService activityService, IUserService userService)
        {
            this.xboxUserService = xboxUserService;
            this.activityService = activityService;
            this.userService = userService;
        }

        // GET: Activity
        public ActionResult UserAndFriendsWeeklyActivity()
        {
            // get user activity (minutes each day for the last week)
            var userId = int.Parse(HttpContext.User.Identity.GetUserId());
            var user = userService.GetUser(userId);
            var xboxUser = xboxUserService.GetXboxUser(user.XboxUserID);
            var userActivities = xboxUser.Activities;

            var usersActivities = userActivities
                .Where(x => x.StartTime >= DateTime.UtcNow.AddDays(-6))
                .GroupBy(x => x.StartTime.Date)
                .ToDictionary(grp => grp.Key, grp => grp.Sum(x => x.SessionDurationInMinutes));

            PopulateEmptyDays(usersActivities);

            // get user's friends activity (minutes each day for the last week)
            var friendsActivities = xboxUser.Friends.SelectMany(a => a.Activities);
            var allActivities = userActivities.Union(friendsActivities);

            var allFriendsActivities = allActivities
               .Where(x => x.StartTime >= DateTime.UtcNow.AddDays(-6))
               .GroupBy(x => x.StartTime.Date)
               .ToDictionary(grp => grp.Key, grp => (int)grp.Average(x => x.SessionDurationInMinutes));

            PopulateEmptyDays(allFriendsActivities);

            //TEMP DATA
            return Json(
                new
                {
                    name = "This weeks activity",
                    labels = new[] {
                        DateTime.UtcNow.Date.AddDays(-6).ToString("dd MMM"),
                        DateTime.UtcNow.Date.AddDays(-5).ToString("dd MMM"),
                        DateTime.UtcNow.Date.AddDays(-4).ToString("dd MMM"),
                        DateTime.UtcNow.Date.AddDays(-3).ToString("dd MMM"),
                        DateTime.UtcNow.Date.AddDays(-2).ToString("dd MMM"),
                        DateTime.UtcNow.Date.AddDays(-1).ToString("dd MMM"),
                        DateTime.UtcNow.Date.ToString("dd MMM")
                    },
                    datasets = new[] {
                        new {
                            label = "Friends Activity",
                            color = "#09355C",
                            fillColor = "rgba(151,187,205,0.2)",
                            strokeColor = "rgba(151,187,205,1)",
                            pointColor = "rgba(151,187,205,1)",
                            pointStrokeColor = "#fff",
                            pointHighlightFill = "#fff",
                            pointHighlightStroke = "rgba(220,220,220,1)",
                            data = new[] {
                                allFriendsActivities[DateTime.UtcNow.Date.AddDays(-6)],
                                allFriendsActivities[DateTime.UtcNow.Date.AddDays(-5)],
                                allFriendsActivities[DateTime.UtcNow.Date.AddDays(-4)],
                                allFriendsActivities[DateTime.UtcNow.Date.AddDays(-3)],
                                allFriendsActivities[DateTime.UtcNow.Date.AddDays(-2)],
                                allFriendsActivities[DateTime.UtcNow.Date.AddDays(-1)],
                                allFriendsActivities[DateTime.UtcNow.Date]}
                        },
                         new {
                            label = "My Activity",
                            color = "#CBCBCB",
                            fillColor = "rgba(0,153,51,0.2)",
                            strokeColor = "rgba(0,153,51,1)",
                            pointColor = "rgba(0,153,51,1)",
                            pointStrokeColor = "#fff",
                            pointHighlightFill = "#fff",
                            pointHighlightStroke = "rgba(151,187,205,1)",
                            data = new[] {
                                usersActivities[DateTime.UtcNow.Date.AddDays(-6)],
                                usersActivities[DateTime.UtcNow.Date.AddDays(-5)],
                                usersActivities[DateTime.UtcNow.Date.AddDays(-4)],
                                usersActivities[DateTime.UtcNow.Date.AddDays(-3)],
                                usersActivities[DateTime.UtcNow.Date.AddDays(-2)],
                                usersActivities[DateTime.UtcNow.Date.AddDays(-1)],
                                usersActivities[DateTime.UtcNow.Date]}
                        }
                    }
                }, JsonRequestBehavior.AllowGet);
        }

        private void PopulateEmptyDays(Dictionary<DateTime, int> activitiesPerDate)
        {
            for (int i = 0; i <= 6; i++)
            {
                if (!activitiesPerDate.ContainsKey((DateTime.UtcNow.AddDays(-i).Date)))
                {
                    activitiesPerDate.Add(DateTime.UtcNow.AddDays(-i).Date, 0);
                }
            }
        } 
    }
}