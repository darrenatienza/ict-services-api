using API.Jwt.Filters;
using V1 = API.Jwt.Models.Inventory.v1;
using V2 = API.Jwt.Models.Inventory.v2;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Queries.Core.Domain.Inventory;

namespace API.Jwt.Controllers.Inventory.v1
{
    [Authorize(Roles = SysRole.Admin)]
    [JwtAuthentication]
    public class InvDetailsController : ApiController
    {
        // GET api/invdetail
        public IHttpActionResult Get(string criteria)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    criteria = criteria == null ? "" : criteria;
                    var invDetails = uow.InvDetails.GetAll_Criteria(criteria);
                    List<V1.InvDetailModel> models = new List<V1.InvDetailModel>();
                    foreach (var item in invDetails)
                    {
                        V1.InvDetailModel model = new V1.InvDetailModel();
                        model.InvDetailID = item.InvDetailID;
                        model.InvType_Description = item.InvType.Description;
                        model.Description = item.Description;
                        model.OtherDetails = item.OtherDetails;
                        model.Specs = item.Specs;
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
        public IHttpActionResult GetAll(int invTypeID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var invDetails = uow.InvDetails.GetAll(invTypeID);
                    List<V1.InvDetailModel> models = new List<V1.InvDetailModel>();
                    foreach (var item in invDetails)
                    {
                        V1.InvDetailModel model = new V1.InvDetailModel();
                        model.InvDetailID = item.InvDetailID;
                        model.InvType_Description = item.InvType.Description;
                        model.Description = item.Description;
                        model.OtherDetails = item.OtherDetails;
                        model.Specs = item.Specs;
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

        // GET api/invdetail/5
        public IHttpActionResult Get(int invDetailID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var invDetail = uow.InvDetails.Get(invDetailID);
                    V2.InvDetailModel model = new V2.InvDetailModel();
                    model.InvDetailID = invDetail.InvDetailID;
                    model.InvTypeID = invDetail.InvTypeID;
                    model.InvType_Description = invDetail.InvType.Description;
                    model.Description = invDetail.Description;
                    model.OtherDetails = invDetail.OtherDetails;
                    model.Specs = invDetail.Specs;
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

       [HttpPost]
        public IHttpActionResult Post(V2.InvDetailModel model)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {

                    var obj = new InvDetail();
                    obj.InvTypeID = model.InvTypeID;
                    obj.Description = model.Description;
                    obj.OtherDetails = model.OtherDetails;
                    obj.Specs = model.Specs;
                    uow.InvDetails.Add(obj);
                    uow.Complete();
                    return Ok(obj.InvDetailID);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        // PUT api/invdetail/5
       public IHttpActionResult Put(int invDetailID, V2.InvDetailModel model)
       {
           try
           {
               using (var uow = new UnitOfWork(new DataContext()))
               {

                   var obj = uow.InvDetails.Get(invDetailID);
                   obj.InvTypeID = model.InvTypeID;
                   obj.Description = model.Description;
                   obj.OtherDetails = model.OtherDetails;
                   obj.Specs = model.Specs;
                   uow.InvDetails.Edit(obj);
                   uow.Complete();
                   return Ok(obj.InvDetailID);
               }
           }
           catch (Exception ex)
           {

               return Content(HttpStatusCode.InternalServerError, ex);
           }
       }

        // DELETE api/invdetail/5
       public IHttpActionResult Delete(int invDetailID)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {

                    var obj = uow.InvDetails.Get(invDetailID);
                    
                    uow.InvDetails.Remove(obj);
                    uow.Complete();
                    return Ok(true);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
