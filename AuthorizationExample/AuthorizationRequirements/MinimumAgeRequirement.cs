using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AuthorizationExample.AuthorizationRequirements
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get; set; }
        public MinimumAgeRequirement(int minimumAge) => MinimumAge = minimumAge; // constructor
    }
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement> {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            var DobClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);
            if (DobClaim is null) {
                return Task.CompletedTask;
            }
            var dob = Convert.ToDateTime(DobClaim?.Value);
            int age = DateTime.Today.Year - dob.Year;
            if (dob.Date > DateTime.Today.AddYears(-age)) age--;
            if (age >= requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
