using API.Jwt.Filters;

using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Queries.Core.Domain.Inventory;
using API.Jwt.Models.Inventory.v1_1;
using System.Web;
using System.IO;
using System.Drawing;

namespace API.Jwt.Controllers.Inventory.v1_1
{
    [Authorize(Roles = SysRole.Admin)]
    [JwtAuthentication]
    public class InvDetailsController : ApiController
    {
        // GET api/invdetail
        public IHttpActionResult Get(string criteria, string type)
        {
            try
            {
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    criteria = criteria == null ? "" : criteria;
                    type = type == null ? "" : type;
                    var invDetails = uow.InvDetails.GetAll_Criteria(criteria, type);
                    List<InvDetailListModel> models = new List<InvDetailListModel>();
                    foreach (var item in invDetails)
                    {
                        InvDetailListModel model = new InvDetailListModel();
                        model.InvDetailID = item.InvDetailID;
                        model.InvType_Description = item.InvType.Description;
                        model.Description = item.Description;
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
       [HttpPost]
        public IHttpActionResult Post(InvDetailModel model)
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

                    if (model.ImageString != "")
                    {
                        SaveImage(model.ImageString, obj.InvDetailID.ToString());
                    }

                    return Ok(obj.InvDetailID);
                }
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
       public IHttpActionResult Put(int invDetailID, InvDetailModel model)
       {

           try
           {
               if (model.ImageString != "")
               {
                   SaveImage(model.ImageString, invDetailID.ToString());
               }
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

       public IHttpActionResult Get(int invDetailID)
       {
           try
           {
               using (var uow = new UnitOfWork(new DataContext()))
               {
                   var invDetail = uow.InvDetails.Get(invDetailID);
                   InvDetailModel model = new InvDetailModel();
                   model.InvDetailID = invDetail.InvDetailID;
                   model.InvTypeID = invDetail.InvTypeID;
                   model.Description = invDetail.Description;
                   model.InvType_Description = invDetail.InvType.Description;
                   model.OtherDetails = invDetail.OtherDetails;
                   model.ImageString = this.GetImage(model.InvDetailID.ToString());
                   model.Specs = invDetail.Specs;
                   return Ok(model);
               }
           }
           catch (Exception ex)
           {

               return Content(HttpStatusCode.InternalServerError, ex);
           }
       }
       public bool SaveImage(string ImgStr, string ImgName)
       {
           String path = HttpContext.Current.Server.MapPath("~/ImageStorage/InvDetails"); //Path

           //Check if directory exist
           if (!System.IO.Directory.Exists(path))
           {
               System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
           }

           string imageName = ImgName + ".png";

           //set the image path
           string imgPath = Path.Combine(path, imageName);
           
           byte[] imageBytes = Convert.FromBase64String(ImgStr);

           File.WriteAllBytes(imgPath, imageBytes);

           return true;
       }
       public string GetImage(string imageName)
       {
           String path = HttpContext.Current.Server.MapPath("~/ImageStorage/InvDetails"); //Path

           //Check if directory exist
           if (!System.IO.Directory.Exists(path))
           {
               System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
           }

           string imgName = imageName + ".png";

           //set the image path
           string imgPath = Path.Combine(path, imgName);
           if (!File.Exists(imgPath))
           {
               imgPath = Path.Combine(path, "thumbnail.png");
           }
           using (Image image = Image.FromFile(imgPath))
           {
               using (MemoryStream m = new MemoryStream())
               {
                   image.Save(m, image.RawFormat);
                   byte[] imageBytes = m.ToArray();

                   // Convert byte[] to Base64 String
                   string base64String = Convert.ToBase64String(imageBytes);
                   return base64String;
               }
           }
       }
       
    }
}
