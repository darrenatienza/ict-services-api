using V3 = API.Jwt.Models.Inventory.v3;
using V1_1 = API.Jwt.Models.Inventory.v1_1;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Queries.Core.Domain.Inventory;
using API.Jwt.Filters;
using API.Jwt.Models.Inventory.v1;
using API.Jwt.Models.Inventory.v1_1;
using API.Jwt.Models.Inventory.v1_1_1;

namespace API.Jwt.Controllers.Inventory.v1_1_1

{
    
    
    public class InvRecordsController : ApiController
    {
        [Authorize(Roles = SysRole.Admin)]
        [JwtAuthentication]
        [HttpGet]
        public IHttpActionResult GetAllByInvDetailID(int invDetailID)
        {
            // get inventory records by inventory detail id
            try
            {
                    using (var uow = new UnitOfWork(new DataContext()))
                    {
                        var objs = uow.InvRecords.GetAllByInvDetailID(invDetailID);
                        List<InvRecordListDTO> models = new List<InvRecordListDTO>();
                        foreach (var item in objs)
                        {
                            InvRecordListDTO model = new InvRecordListDTO();
                            model.InvRecordID = item.InvRecordID;
                            model.PropertyNum = item.PropertyNum;
                            model.EquipNum = item.InvDetail.InvType.Code + item.EquipNum;
                            model.InvLocation_Description = item.InvLocation.Description;
                            // if inventory status is null set inventory status from status field
                            if (item.InvStatID == null)
                            {
                                model.Status = item.Status;
                            }
                            else
                            {
                                model.Status = item.InvStat.Description;
                            }
                            
                            models.Add(model);
                        }
                        return Ok(models);
                    }
                
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        
    }
}
