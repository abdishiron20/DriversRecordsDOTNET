using Humanizer.Localisation;
using Humanizer;
using Microsoft.Build.Evaluation;
using Microsoft.Extensions.Hosting;
using static System.Net.WebRequestMethods;

namespace Dispatch_app.Models
{
    public class TractorRequest
    {
        //A request is made by a client(e.g., a web browser) to a server to retrieve or send data.
        //It consists of various components, including:
        //HTTP Method: Specifies the type of operation to be performed 
        //on the resource (e.g., GET, POST, PUT, DELETE).


        public int ID { get; set; }
        
        public string Make { get; set; }
        public string YearMade { get; set; }
        public string Model  { get; set; }
        public string VinNumber { get; set; }
  
    }
}
