using System.Collections.Generic;
using CodemashApp.Interfaces;
using CodemashApp.Models;
using CodemashApp.Resources;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CodemashApp.Controllers
{
    [Route("api/[controller]")]
    public class SpeakerController : Controller
    {
        private ICodemashUnitOfWork UnitOfWork { get; set; }

        public SpeakerController(ICodemashUnitOfWork uow)
        {
            UnitOfWork = uow;
        }

        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            var list = JsonConvert.DeserializeObject<List<Speaker>>(JsonResources.PublicSpeakerDataModel);

            // When we actually have a list of speakers, uncomment this line.
            // var list = UnitOfWork.SpeakerRepository.GetAllAsync();

            return Json(list);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
