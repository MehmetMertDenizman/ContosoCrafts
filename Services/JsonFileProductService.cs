using ContosoCrafts.WebSite.Models;
using System.Security.AccessControl;
using System.Text.Json;

namespace ContosoCrafts.WebSite.Services
{
    public class JsonFileProductService
    {
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;

        }
        public IWebHostEnvironment WebHostEnvironment { get; set; }


        private string JsonFileName { get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "product.json"); } }


        public IEnumerable<Product> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}
