using System.Collections.Generic;
using Scozzard.Model;
using Scozzard.Respository.Infrastructure;
using Scozzard.Respository.Repositories;
using Scozzard.Service.Interfaces;
using System.Linq;

namespace Scozzard.Service
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository activityRepository;
        private readonly IUnitOfWork unitOfWork;

        public ActivityService(IActivityRepository activityRepository, IUnitOfWork unitOfWork)
        {
            this.activityRepository = activityRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Activity> GetActivities()
        {
            var activities = activityRepository.GetAll();
            return activities;
        }

        public IEnumerable<Activity> GetXboxUserActivities(long xboxUserId)
        {
            var activities = activityRepository.GetAll().Where(x => x.XboxUserID == xboxUserId);
            return activities;
        }

        public Activity GetActivity(int id)
        {
            var activity = activityRepository.GetById(id);
            return activity;
        }

        public void CreateActivity(Activity activity)
        {
            activityRepository.Add(activity);
        }

        public void UpdateActivity(Activity activity)
        {
            activityRepository.Update(activity);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}
