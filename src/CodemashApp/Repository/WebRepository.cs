using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CodemashApp.Interfaces;

namespace CodemashApp.Repository
{
    public class WebRepository<T> : IWebRepository<T> where T : class
    {
        public Uri Uri { get; set; }

        public WebRepository(Uri url)
        {
            Uri = url;
        }

        public virtual IEnumerable<T> GetRecords(string data)
        {
            return null;
        }

        public virtual T GetRecord(string data)
        {
            return null;
        }

        private async Task<string> GetData(Uri uri, string headerType = "json")
        {
            var response = String.Empty;
            var handler = new HttpClientHandler();
            using (var httpClient = new HttpClient(handler))
            {
                httpClient.BaseAddress = uri;
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/" + headerType));
                var apiResponse = await httpClient.GetAsync(uri.AbsoluteUri);
                if (apiResponse.IsSuccessStatusCode)
                {
                    response = await apiResponse.Content.ReadAsStringAsync();
                    //do something with the response here. Typically use JSON.net to deserialise it and work with it
                }
            }

            return response;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return null;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var data = await GetData(Uri, "json");
            return GetRecords(data);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var newUri = new Uri(Uri + "/" + id);
            var data = await GetData(newUri);
            return GetRecord(data);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
        }
    }
}