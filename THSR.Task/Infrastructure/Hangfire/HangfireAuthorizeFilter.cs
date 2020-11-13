using System;
using System.Linq;
using Hangfire.Annotations;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Http;

namespace THSR.Task.Infrastructure.Hangfire
{
    public class HangfireAuthorizeFilter : IDashboardAuthorizationFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HangfireAuthorizeFilter"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">The HttpContextAccessor.</param>
        /// <param name="users">The users.</param>
        public HangfireAuthorizeFilter(IHttpContextAccessor httpContextAccessor, string[] users)
        {
            this.HttpContextAccessor = httpContextAccessor;
            this.DashboardUsers = users;
        }

        private IHttpContextAccessor HttpContextAccessor { get; set; }

        private string[] DashboardUsers { get; set; }
        //-----------------------------------------------------------------------------------------

        public bool Authorize([NotNull] DashboardContext context)
        {
            var userName = this.HttpContextAccessor.HttpContext.User.Identity.Name;
            var isAuthenticated = this.IsAuthenticated(userName);
            return isAuthenticated;
        }

        /// <summary>
        /// Determines whether this instance is authenticated.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns><c>true</c> if this instance is authenticated; otherwise, <c>false</c>.</returns>
        private bool IsAuthenticated(string userName)
        {
            if (this.DashboardUsers is null || this.DashboardUsers.Any().Equals(false))
            {
                return false;
            }

            if (this.DashboardUsers.Contains("*"))
            {
                return true;
            }

            var result = this.DashboardUsers.Contains(userName);
            return result;
        }
    }
}