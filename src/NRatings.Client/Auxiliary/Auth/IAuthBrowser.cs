using System.Windows.Forms;
using Duende.IdentityModel.OidcClient.Browser;

namespace NRatings.Client.Auxiliary.Auth
{
    public interface IAuthBrowser : IBrowser
    {
        string OidcLoginRedirectUri { get; }
        string OidcLogoutRedirectUri { get; }
        Form CallingForm { get; set; }
        string StartUrl { get; }
    }
}