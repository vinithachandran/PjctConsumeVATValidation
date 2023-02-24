using Microsoft.AspNetCore.Mvc;
using PjctConsumeVATValidation.Models;
using System.Diagnostics;


namespace PjctConsumeVATValidation.Controllers
{
    public class HomeController : Controller
    {   
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult VAThome()
        {
            return View();
        }
        public async Task<string> VATvalidationhome(String Country, String VatNo)
        {
            try
            {
                String message = "";
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("https://localhost:7267/api/vat/validation?CountryCode=" + Country + "&VatNo=" + VatNo))
                    {
                        message = await response.Content.ReadAsStringAsync();
                    }
                    return message;


                }
            }
            catch (Exception ex)
            {
                //Question-3
                // If API is not available we can show some customized message to User. and Log this exception info to table level.
                //Can check the issue immediately based on this data
                return "Currently API is not available. please connect after some time";
            }

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}