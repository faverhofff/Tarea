using System.Web.Http;
using ApiTarea.Services;
using ApiTarea.Models;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace ApiTarea.Controllers
{
    [RoutePrefix("api")]
    public class ApplicationController : ApiController
    {
        protected Aplication _Service { get; set; }

        public ApplicationController()
        {
            _Service = new Aplication();                
        }

        [HttpGet]
        // [HttpOptions]
        [Route("search")]
        public IHttpActionResult Search(Search Form)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Json(_Service.Search(Form.Word));
        }

        [HttpPost]
        [HttpGet]
        [Route("index")]
        public IHttpActionResult IndexPage([FromBody] IndexUrl Site)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            IndexUrl n = new IndexUrl();
            n.Url = "http://192.168.56.101:83/login";
            return Json(_Service.Scrap(new List<string>() { n.Url }));
        }

        [HttpGet]
        [Route("clear")]
        public IHttpActionResult ClearPage([FromBody] IndexUrl Site)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _Service.RemoveIndexContent();

            return Json(new List<bool>() { true });
        }


    }
}
