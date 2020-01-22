using System;
using System.Collections.Generic;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class BaseViewModel
    {
        // View title
        public string Title { get; set; } = "";

        // All columns, for display
        public List<JobFieldType> Columns { get; set; }

        // The column to search, defaults to all
        public JobFieldType Column { get; set; } = JobFieldType.All;

        public BaseViewModel()
        {
            Columns = new List<JobFieldType>();

            foreach (JobFieldType enumVal in Enum.GetValues(typeof(JobFieldType)))
            {
                Columns.Add(enumVal);
            }

        }

    }
}
    

