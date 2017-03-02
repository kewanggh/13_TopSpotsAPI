using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TopSpots.Models;

namespace TopSpots.Controllers
{
    public class TopSpotsController : ApiController
    {
        // GET: api/TopSpots
        public IEnumerable<TopSpot> Get()
        {
            String JSONstring = File.ReadAllText(@"c:\dev2\13_TopSpotsAPI\TopSpots\TopSpots\App_Data\topspots.json");
            List<TopSpot> myList = JsonConvert.DeserializeObject<List<TopSpot>>(JSONstring);
            Console.WriteLine(myList);
            return myList;
        }

        // GET: api/TopSpots/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TopSpots
        public void Post([FromBody]TopSpot value)
        {
            var filePath = @"c:\dev2\13_TopSpotsAPI\TopSpots\TopSpots\App_Data\topspots.json";
            // Read existing json data
            var JSONstring = File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var myList = JsonConvert.DeserializeObject<List<TopSpot>>(JSONstring)
                                ?? new List<TopSpot>();

            //Add any new employees
            myList.Add(new TopSpot()
            {
                /*name = "Test Person 1",
                description = "something",
                location = new float[] { 32.990f, 17.890f }*/
                name = value.name,
                description = value.description,
                location = value.location
            });


            //Update json data string
            JSONstring = JsonConvert.SerializeObject(myList);
            File.WriteAllText(filePath, JSONstring);
        }

        // PUT: api/TopSpots/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/TopSpots/5
        public void Delete(int id)
        {
        }
    }
}
