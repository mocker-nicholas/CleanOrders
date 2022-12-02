using Microsoft.AspNetCore.Authorization;

namespace CleanOrders.API.Policies
{
    public class AuthorizationPolicy : IAuthorizationRequirement
    {

    }

    public class AuthorizationPolicyHandler : AuthorizationHandler<AuthorizationPolicy>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationPolicy requirement)
        {
            throw new NotImplementedException();
        }
    }
}
