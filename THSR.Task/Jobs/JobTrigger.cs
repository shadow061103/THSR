using System;
using Hangfire;
using THSR.Task.Interfaces;

namespace THSR.Task.Jobs
{
    public class JobTrigger : IJobTrigger
    {
        public void OnStart()
        {
            RecurringJob.AddOrUpdate<ITHSRInitialJob>
                (
                x => x.DataBaseDataInitialCreate(null),
                "0 8 * * *",
                TimeZoneInfo.Local
                );
        }
    }
}