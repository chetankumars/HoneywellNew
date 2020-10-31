using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Honey.Application
{
    public class S3DownloadResponse
    {
       
        public HttpStatusCode HttpStatusCode { get; set; }

      
        public Stream Stream { get; set; }

       
        public long ContentLength { get; set; }
    }
}
