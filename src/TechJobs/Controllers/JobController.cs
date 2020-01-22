using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        [HttpGet]
        public IActionResult Index(int id)
        {
            // TODO #1 - get the Job with the given ID and pass it into the view

            Job jobID = jobData.Find(id);
            return View(jobID);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.

            if (ModelState.IsValid) { // if all form fields successfully validated at submission

                Job newJob = new Job() // create a new job with the properties from form fields
                {
                    Name = newJobViewModel.Name,
                    Employer = jobData.Employers.Find(newJobViewModel.EmployerID),
                    Location = jobData.Locations.Find(newJobViewModel.LocationID),
                    CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetencyID),
                    PositionType = jobData.PositionTypes.Find(newJobViewModel.PositionTypeID)
                };

            jobData.Jobs.Add(newJob); // add the new job into the data store of jobs

            string url = "/Job?id=" + newJob.ID;
            return Redirect(url);
             // direct user to job page by job id (index)
            }

        return View(newJobViewModel);
        }
    }
}
