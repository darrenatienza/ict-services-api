using API.Jwt.Models.Person;
using API.Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Jwt.Controllers.Person.v1
{
    public class EmployeesController : ApiController
    {
        // GET api/student
        [HttpGet]
        [AllowAnonymous]
        //[Authorize(Roles = SysRole.Admin_SOAHead)]
        public async Task<IHttpActionResult> Get(string criteria)
        {
            try
            {
                criteria = criteria == null ? "" : criteria;
                using (var uow = new UnitOfWork(new DataContext()))
                {
                    var objs = await Task.Run(() => uow.Employees.GetAll(criteria).ToList());
                    List<EmployeeListDto> models = new List<EmployeeListDto>();
                    foreach (var item in objs)
                    {
                        EmployeeListDto model = new EmployeeListDto();
                        model.EmployeeID = item.EmployeeID;
                        model.College = item.College == null ? "" : item.College.Description;
                        model.FullName = item.FirstName + item.MiddleName + item.LastName;

                        model.Office = item.Office.Description;
                        models.Add(model);
                    }
                    return Ok(models);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // GET api/employees/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/employees
        public void Post([FromBody]string value)
        {
        }

        // PUT api/employees/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/employees/5
        public void Delete(int id)
        {
        }
    }
}
