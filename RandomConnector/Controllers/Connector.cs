using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomConnector.Controllers.Model;
using RandomConnector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomConnector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Connector : Controller
    {
        private static readonly string[] Summaries = new[]
         {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("id")]
        public Guid GetId()
        {
            return Guid.Parse("d7505861-5050-4f33-b3eb-5de72e9b1cad");
        }


        [HttpGet("healthCheck")]
        public bool HealthCheck()
        {
            return true;
        }

        [HttpGet("ensureCredentials")]
        public DataSourceMetadata EnsureCredentialsAsync()
        {
            return new DataSourceMetadata()
            {
                DisplayName = "c:/FilesTest",
            };
        }

        [HttpGet("ensureConfiguration")]
        public bool EnsureConfiguration()
        {
            return true;
        }

        [HttpGet("moveNext")]
        public List<SearchableItem> MoveNext(string checkPoint)
        {
            if(checkPoint == null)
            {
                return new List<SearchableItem>()
                {
                    new SearchableItem()
                    { 
                        Id = "1",
                        Properties = new Dictionary<string, object>()
                        {
                            {"firstname", "anubhav" },
                            {"lastname", "shrivastava" }
                        }
                    }
                    ,

                    new SearchableItem()
                    {
                        Id = "2",
                        Properties = new Dictionary<string, object>()
                        {
                            {"firstname", "abhinav" },
                            {"lastname", "shrivastava" }
                        }
                    }
                };
            }
            else
            {
                return null;
            }
        }
    }
}
