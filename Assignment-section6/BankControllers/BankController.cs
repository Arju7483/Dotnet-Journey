using Microsoft.AspNetCore.Mvc;

namespace Assignment_section6.BankControllers
{
    [Controller]
    public class BankController : Controller
    {
        [Route("/account-details")]
        public JsonResult getDetail()
        {
            return new JsonResult(new
            {
                accountNumber = 1001,
                accountHolderName = "Example Name",
                currentBalance = 5000
            });
        }
        [Route("/account-statement")]
        public VirtualFileResult getFile()
        {
            var file = new VirtualFileResult("/account-statement.pdf", "application/pdf");
            //file.FileDownloadName = "sample.pdf";
            return file;
        }
        [Route("/get-current-balance/{accountNumber?}")]
        public IActionResult getBalance(int? accountNumber)
        {
            if(accountNumber == null) return NotFound("Account Number should be supplied");
            if (accountNumber == 1001)
                return Ok(5000);
            else return BadRequest("Account Number should be 1001");
        }

    }
}
