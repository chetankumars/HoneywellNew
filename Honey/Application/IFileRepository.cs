using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Honey.Application
{
    public interface IFileRepository
    {
        S3DownloadResponse Download(string filePath);
    }
}
