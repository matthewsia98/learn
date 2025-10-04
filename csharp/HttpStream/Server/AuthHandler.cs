using System.Security.Claims;
using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Server;

class AuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly Runtime runtime;
    public AuthHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        Runtime runtime
    ) : base(options, logger, encoder, clock)
    {
        this.runtime = runtime;
    }
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (runtime.User is null)
        {
            return Task.FromResult(AuthenticateResult.Fail("Not logged in"));
        }
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, runtime.User),
            new(ClaimTypes.Role, "Admin"),
        };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);

        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}
