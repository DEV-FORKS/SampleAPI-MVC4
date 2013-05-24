using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using Bucket.BL;
using Bucket.Models;
using RL;
using Bucket.Resources;
using ServiceStack.Text;

namespace Bucket.Controllers
{

    [AuthenticationActionFilter]
    [ExceptionActionFilter]
    public class UserActivityController : Controller
    {
    }
}
