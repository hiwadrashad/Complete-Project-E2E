using Complete_Project_E2E.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using System.Diagnostics;

namespace Complete_Project_E2E.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly GraphServiceClient _graphServiceClient;

        public HomeController(GraphServiceClient graphServiceClient)
        {
            _graphServiceClient = graphServiceClient;
        }

        [AuthorizeForScopes(ScopeKeySection = "MicrosoftGraph:Scopes")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var user = await _graphServiceClient.Me.GetAsync();
                ViewData["GraphApiResult"] = user?.DisplayName ?? "Unknown user";
            }
            catch (Microsoft.Identity.Web.MicrosoftIdentityWebChallengeUserException)
            {
                // The [AuthorizeForScopes] attribute should handle this, 
                // but as a fallback, trigger a new authentication challenge
                return Challenge();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
