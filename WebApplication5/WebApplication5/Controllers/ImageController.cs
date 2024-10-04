using System.IO;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        // POST: Image/Upload
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                // Define the path where you want to save the uploaded image
                var fileName = Path.GetFileName(file.FileName);
                var uploadDir = "~/UploadedImages/";
                var path = Path.Combine(Server.MapPath(uploadDir), fileName);

                // Save the image to the server
                file.SaveAs(path);

                // Save image details to database (optional)
                Image image = new Image
                {
                    Img_Name_ = fileName,
                    Img_Path = Url.Content(uploadDir + fileName) // Convert to URL for displaying the image in view
                };

                // Pass the image details to the view
                ViewBag.Image = image;
                ViewBag.Message = "Image uploaded successfully!";
            }
            else
            {
                ViewBag.Message = "Please select an image to upload.";
            }
            return View("Index");
        }
    }
}
