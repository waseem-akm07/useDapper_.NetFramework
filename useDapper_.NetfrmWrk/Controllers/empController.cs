using System.Collections.Generic;
using System.Web.Http;
using DataTransferObject.DTO;
using BusinessAccessLayer.Repo;

namespace useDapper_.NetfrmWrk.Controllers
{
    public class empController : ApiController
    {
        private IBusinessLayer _businessLayer = new BusinessLayer();


        // GET: api/emp
        [HttpGet]
        [Route("api/emp/getemployees")]
        public IEnumerable<HelperModel> GetEmployees()
        {
            return _businessLayer.GetEmployees();
        }

        // GET: api/emp/5
        [HttpGet]
        [Route("api/emp/getemployee/{id}")]
        public IEnumerable<HelperModel> GetEmployee(int id)
        {
            return _businessLayer.GetEmployeeById(id);
        }

        // POST: api/emp
        [HttpPost]
        [Route("api/emp/postemployee")]
        public void Post(HelperModel model)
        {
            _businessLayer.Create(model);
        }

        // PUT: api/emp/5
        [HttpPut]
        [Route("api/emp/putemployee/{id}")]
        public void Put(int id, HelperModel model)
        {
            _businessLayer.Update(id, model);
        }

        // DELETE: api/emp/5
        [HttpDelete]
        [Route("api/emp/delete/{id}")]
        public void Delete(int id)
        {
            _businessLayer.Delete(id);
        }
    }
}
