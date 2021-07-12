using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
namespace holaMundo.Controllers
{
    public class UsuariosController : Controller
    {
        private IWebHostEnvironment _e;
        public UsuariosController(IWebHostEnvironment env){
            _e = env;
        }

        public IActionResult Index() {
            return View();
        }

        public ContentResult Id() {
            return Content("<h1>2089</h1>", "text/html");
        }

        public ActionResult getId(bool founded) {
            if(founded)
                return Content("<h1>Registros encontrados!</h2>", "text/html");
            else
                return StatusCode(500);
        }

        public FileStreamResult getPDF(){
            String filePath = Path.Combine(_e.WebRootPath, "cv.pdf");
            FileStream fs;
            if(System.IO.File.Exists(filePath)){
                fs = new FileStream(filePath, FileMode.Open);
                return File(fs, "application/pdf");
            } else {
                filePath = Path.Combine(_e.WebRootPath, "noPDF.pdf");
                fs = new FileStream(filePath, FileMode.Open);
                return File(fs, "application/pdf");
            }   
        }

          public ActionResult getPDF2(){
            String filePath = Path.Combine(_e.WebRootPath, "cv.pdf");
            FileStream fs;
            if(System.IO.File.Exists(filePath)){
                fs = new FileStream(filePath, FileMode.Open);
                return File(fs, "application/octect-stream", "curriculum.pdf");// "application/pdf" para abrir el archivo
            } else {
                return Content("<h1>Error cargando el archivo</h1>", "text/html");
            }   
        }
    }
}