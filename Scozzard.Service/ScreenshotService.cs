using System.Collections.Generic;
using Scozzard.Model;
using Scozzard.Respository.Infrastructure;
using Scozzard.Respository.Repositories;
using Scozzard.Service.Interfaces;
using System.Linq;

namespace Scozzard.Service
{
    public class ScreenshotService : IScreenshotService
    {
        private readonly IScreenshotRepository screenshotRepository;
        private readonly IUnitOfWork unitOfWork;

        public ScreenshotService(IScreenshotRepository screenshotRepository, IUnitOfWork unitOfWork)
        {
            this.screenshotRepository = screenshotRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Screenshot> GetScreenshots()
        {
            var screenshots = screenshotRepository.GetAll();
            return screenshots;
        }

        public IEnumerable<Screenshot> GetXboxUserScreenshots(long xboxUserId)
        {
            var screenshots = screenshotRepository.GetAll().Where(x => x.XboxUserID == xboxUserId);
            return screenshots;
        }

        public Screenshot GetScreenshot(int id)
        {
            var screenshot = screenshotRepository.GetById(id);
            return screenshot;
        }

        public void CreateScreenshot(Screenshot screenshot)
        {
            screenshotRepository.Add(screenshot);
        }

        public void UpdateScreenshot(Screenshot screenshot)
        {
            screenshotRepository.Update(screenshot);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}
