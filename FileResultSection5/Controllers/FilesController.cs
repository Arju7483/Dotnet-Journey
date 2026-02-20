using Microsoft.AspNetCore.Mvc;

namespace FileResultSection5.Controllers
{
    [Controller]
    [Route("/file")]
    public class FilesController : ControllerBase
    {
        [Route("pdf")]
        //example of virtual file result type
        public VirtualFileResult ServePdf()
        {
            var file = new VirtualFileResult("/PdfFiles/demopdf.pdf", "application/pdf");
            file.FileDownloadName = "sample.pdf";
            return file;
        }
        // example of physical fileResult type
        [Route("pdf2")]
        public PhysicalFileResult ServePdf2()
        {
            var filePath = @"C:\Users\mahbub.arju\OneDrive - BRAC IT Services Limited\download\application-1.pdf";
            var file = new PhysicalFileResult(filePath, "application/pdf");
            return file;
        }
        // example of file content result
        [Route("pdf3")]
        public FileContentResult ServePdf3()
        {
            var filePath = @"C:\Users\mahbub.arju\OneDrive - BRAC IT Services Limited\download\application-1.pdf";
            Byte[] file = System.IO.File.ReadAllBytes(filePath);
            return new FileContentResult(file, "application/pdf");
        }
    }
}
