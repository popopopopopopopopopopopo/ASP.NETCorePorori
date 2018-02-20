using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ASP.NETCorePorori.Models;
using ASP.NETCorePorori.Utilities;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASP.NETCorePorori.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private AsyncLocal<HogeModel> factory 
            = new AsyncLocal<HogeModel>(hoge => Console.WriteLine($"Current:{hoge.CurrentValue?.Id}_Prev{hoge.PreviousValue?.Id}"));

        // GET api/values
        [HttpGet]
        public IEnumerable<HogeModel> Get()
        {
            var hogeString = "";
            HogeModel hoge = null;
            object hogeObject = null;
            if (TempData.TryGetValue("Hoge", out hogeObject))
            {
                hogeString = hogeObject?.ToString();
                if (!string.IsNullOrEmpty(hogeString))
                {
                    hoge = JsonConvert.DeserializeObject<HogeModel>(hogeString);
                }
            }
            else
            {
                hoge = factory.Value ?? (factory.Value = new HogeModel());
            }

            if (hoge == null)
            {
                hoge = factory.Value ?? (factory.Value = new HogeModel());
                TempData["Hoge"] = JsonConvert.SerializeObject(hoge);
            }

            TempData["Hoge"] = JsonConvert.SerializeObject(hoge);

            return new HogeModel[] { hoge };
            //return new string[] { "value1", "value2" };
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
