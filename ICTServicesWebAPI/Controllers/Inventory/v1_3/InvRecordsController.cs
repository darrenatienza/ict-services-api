using V1_2 = API.Jwt.Models.Inventory.v1_2;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Queries.Core.Domain.Inventory;
using API.Jwt.Filters;
using API.Jwt.Models.Inventory.v1_3;

namespace API.Jwt.Controllers.Inventory.v1_3

{
    [Authorize(Roles = SysRole.Admin)]
    [JwtAuthentication]
    public class InvRecordsController : ApiController
    {
        
        
    }
}
