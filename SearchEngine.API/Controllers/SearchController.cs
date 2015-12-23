using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SearchEngine.API.EntityClasses;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;
namespace SearchEngine.API.Controllers
{
    [EnableCorsAttribute("http://localhost:34487", "*", "*")]
    public class SearchController : ApiController
    {
        private searchModelContainer db = new searchModelContainer();

        // GET api/Search
        public IEnumerable<Search> GetSearches()
        {

            return db.Searches.AsEnumerable();
        }
        public string SearchData()
        {
            var data = db.Searches.AsEnumerable();
            return Json(data).ToString();
        }

        // GET api/Search/5
        public Search GetSearch(int id)
        {
            Search search = db.Searches.Find(id);
            if (search == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return search;
        }

        // PUT api/Search/5
        public HttpResponseMessage PutSearch(int id, Search search)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != search.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(search).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Search
        public HttpResponseMessage PostSearch(Search search)
        {
            if (ModelState.IsValid)
            {
                db.Searches.Add(search);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, search);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = search.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Search/5
        public HttpResponseMessage DeleteSearch(int id)
        {
            Search search = db.Searches.Find(id);
            if (search == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Searches.Remove(search);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, search);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}