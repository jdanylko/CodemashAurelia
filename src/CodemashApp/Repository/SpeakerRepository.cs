using System;
using System.Collections.Generic;
using CodemashApp.Models;
using Newtonsoft.Json;

namespace CodemashApp.Repository
{
    public class SpeakerRepository : WebRepository<Speaker>
    {
        public SpeakerRepository(Uri url) : base(url) { }

        public override IEnumerable<Speaker> GetRecords(string data)
        {
            return JsonConvert.DeserializeObject<List<Speaker>>(data);
        }

        public override Speaker GetRecord(string data)
        {
            return JsonConvert.DeserializeObject<Speaker>(data);
        }

    }
}