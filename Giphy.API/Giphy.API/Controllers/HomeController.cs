using System.IO;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace Giphy.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["giphyAPIKey"];

            //Create the request to the API
            WebRequest request = WebRequest.Create("http://api.giphy.com/v1/gifs/search?q=funny+cat&api_key=" + apiKey + "&offset=1");
            //Send request off
            WebResponse response = request.GetResponse();
            //Get back the response stream
            Stream stream = response.GetResponseStream();
            //Make it accessable
            StreamReader reader = new StreamReader(stream);
            //Put into string. Which is json format
            string responseFromServer = reader.ReadToEnd();

            JObject parsedString = JObject.Parse(responseFromServer);
            Pokemon myPokemon = parsedString.ToObject<Pokemon>();

            //myPokemon.moves[0].move.name;



            return View(myPokemon);
        }
    }
}