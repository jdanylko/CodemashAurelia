using System;
using System.Collections.Generic;
using CodemashApp.Models;
using Newtonsoft.Json;

namespace CodemashApp.Repository
{
    public class SessionRepository : WebRepository<Session>
    {
        public SessionRepository(Uri url) : base(url) { }

        public override IEnumerable<Session> GetRecords(string data)
        {
            return JsonConvert.DeserializeObject<List<Session>>(data);
        }

        public override Session GetRecord(string data)
        {
            return JsonConvert.DeserializeObject<Session>(data);
        }
    }
}