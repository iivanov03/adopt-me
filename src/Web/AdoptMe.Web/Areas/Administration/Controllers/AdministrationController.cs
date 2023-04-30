﻿namespace AdoptMe.Web.Areas.Administration.Controllers
{
    using AdoptMe.Common;
    using AdoptMe.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
