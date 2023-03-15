using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Newtonsoft.Json;
using Owin;
using System.Security.Claims;
using System.Threading.Tasks;


[assembly: OwinStartup(typeof(Alt_Forms_OpenIDConnect_Sample.Startup))]

namespace Alt_Forms_OpenIDConnect_Sample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                LoginPath = new PathString("/Auth/Login"),
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType
            });

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions()
                {
                    ClientId="test-client",
                    MetadataAddress = "https://darrenhoy.ddns.net/sso/realms/main/.well-known/openid-configuration",
                    AuthenticationMode = AuthenticationMode.Passive,
                    RedirectUri = "https://localhost:44394",
                    AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                    
                }); ;
        }
    }
}
