using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Honey.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace Honey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IFileRepository _fileRep;

        public UploadController(IFileRepository fileRep)
        {
            this._fileRep = fileRep;
        }
        /// <summary>
        /// Api to get Download file from bucket 
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpGet("{fileId}")]
        public IActionResult Get(string fileId)
        {
            var filePath = "Mazon File Bucket";
            var s3Response = _fileRep.Download(filePath);

            if (s3Response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                Response.ContentLength = s3Response.ContentLength;
                return File(s3Response.Stream, "application/octet-stream");
            }
            else if (s3Response.HttpStatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode((int)s3Response.HttpStatusCode);
            }
        }
       
    }
}