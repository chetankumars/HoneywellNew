using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Honey.Application
{
    public class FileRepository : IFileRepository
    {
        private const string accessKey = "XXXXXXX";
        private const string secretKey = "XXXXXXX";
        private Amazon.RegionEndpoint _s3Region;
        private string _s3BucketName;
        private IAmazonS3 _s3;
        /// <summary>
        /// Bind the S3Region and S3Bucket 
        /// </summary>
        /// <param name="s3Region"></param>
        /// <param name="s3BucketName"></param>
        public FileRepository(Amazon.RegionEndpoint s3Region, string s3BucketName)
        {
            _s3Region = s3Region;
            _s3BucketName = s3BucketName;
        }
        /// <summary>
        /// Download file and get the response
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public S3DownloadResponse Download(string filePath)
        {
            using (var s3 = new AmazonS3Client(_s3Region))
            {
                var initiateRequest = new GetObjectRequest
                {
                    BucketName = _s3BucketName,
                    Key = filePath
                };

                GetObjectResponse response = null;
                try
                {
                    response = s3.GetObjectAsync(initiateRequest).Result;
                }
                catch
                {
                    throw;
                }
                return new S3DownloadResponse() { HttpStatusCode = response.HttpStatusCode, Stream = response.ResponseStream, ContentLength = response.ContentLength };
            }
            
        }
    }
}
