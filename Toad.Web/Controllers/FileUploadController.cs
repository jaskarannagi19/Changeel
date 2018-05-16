using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Toad.Web.Models;
using Toad.Web.Services;

namespace Toad.Web.Controllers
{
    [RoutePrefix("api")]
    public class FileUploadController : ApiController
    {
        [Authorize]
        [Route("Upload"), HttpPost]
        public async Task<IHttpActionResult> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
            string subpath = "/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/";
            string uploadpath = "~/images" + subpath;

            var var = Directory.Exists(uploadpath);


            var localFilePath = new HttpServerUtilityWrapper(HttpContext.Current.Server).MapPath(uploadpath);

            var directory = System.IO.Path.GetDirectoryName(localFilePath);

            if (!System.IO.Directory.Exists(localFilePath))
            {
                System.IO.Directory.CreateDirectory(directory);
            }




            var uploadProcessor = new FlowUploadProcessor(uploadpath);
            await uploadProcessor.ProcessUploadChunkRequest(Request);

            if (uploadProcessor.IsComplete)
            {
                // Do post processing here:
                // - Move the file to a permanent location
                // - Persist information to a database
                // - Raise an event to signal it was completed (if you are really feeling up to it)
                //      - http://www.udidahan.com/2009/06/14/domain-\events-salvation/
                //      - http://msdn.microsoft.com/en-gb/magazine/ee236415.aspx#id0400079
            }

            return Ok();
        }

        [Authorize]
        [Route("Upload"), HttpGet]
        public IHttpActionResult TestFlowChunk([FromUri]FlowMetaData flowMeta)
        {
            if (FlowUploadProcessor.HasRecievedChunk(flowMeta))
            {
                return Ok();
            }

            return NotFound();
        }


    }
}