using System.Net;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json.Linq;
using PokEmployment.API.Models;

namespace PokEmployment.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Create the request to the API
            WebRequest request = WebRequest.Create("http://pokeapi.co/api/v2/pokemon/431/");
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