using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QuickKartWebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : Controller
    {

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var fileName = file.FileName;
                string url = "";
                if (file.Length > 0)
                {

                    string connectionString = "DefaultEndpointsProtocol=https;AccountName=quickcartstorage;AccountKey=ka3p1LOkh6rM4cwBUv5/oDsmfccN2EF1lLF6YP09i618Nq4na2GuomcqZXuoQ8Mc4Ohcc0mD9Dbm+AStcGEfeQ==;EndpointSuffix=core.windows.net";
                      // string connectionString = "DefaultEndpointsProtocol=https;AccountName=quickcartteam5b342;AccountKey=DUoCCr73z4DhY6A8ZhfIuSTQ+fwi3J+pQg6u3qVEJVRstui51NVYWk+a1baugqEhgrXFWNH3fFGQ+AStq8IEUw==;EndpointSuffix=core.windows.net";
                   string containerName = "data";
                  // string containerName = "image5";
                    BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

                    try
                    {
                        // Get a reference to a blob
                        BlobClient blob = container.GetBlobClient(fileName);

                        // Open the file and upload its data
                        using (Stream file1 = file.OpenReadStream())
                        {
                            blob.Upload(file1);
                        }

                         url = blob.Uri.AbsoluteUri;
                    }
                    catch
                    {
                        return BadRequest();
                    }

                    return Ok(url);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }





    }
}
