using System.Collections.Generic;
using System.Drawing;
using System.Web.Http;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Controllers
{
    [RoutePrefix("api/ImageUpload")]
    public class ImageUploadController : ApiController
    {
        [Route("Upload")]
        [HttpPost]
        public IHttpActionResult Upload(List<string> obj)
        {
            try
            {
                string base64String = obj[0];
                string fileName = obj[1];
                Image image = MethodRepo.Base64ToImage(base64String);
                image.Save($@"/Resources/Images/{fileName}");
                return Ok(true);
            }
            catch
            {
                return Conflict();
            }
        }
    }
}
