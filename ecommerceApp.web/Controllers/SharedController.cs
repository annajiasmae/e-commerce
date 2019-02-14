using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace ecommerceApp.web.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            try
            {
                var file = Request.Files[0];
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);//file.FileName;
                var path = Path.Combine(Server.MapPath("~/images/"), fileName);
                file.SaveAs(path);
                result.Data = new { Success = true, ImageUrl = string.Format("/images/{0}",fileName) };
                
            }
            catch(Exception Ex)
            {
                result.Data = new { Success = false, Message = Ex.Message };
            }
            return result;
        }
    }
}