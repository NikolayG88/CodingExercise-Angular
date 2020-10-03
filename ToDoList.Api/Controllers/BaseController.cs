using Microsoft.AspNet.Identity.Owin;
using System.Net.Http;
using System.Web.Http;

namespace CodingExercise.API.Controllers
{
    public class BaseController : ApiController
    {
        private ApplicationUserManager _userManager;

        public BaseController()
        {

        }

        public ApplicationUserManager UserManager
        {
            get
            {
                _userManager = _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
                return _userManager;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }
    }
}
