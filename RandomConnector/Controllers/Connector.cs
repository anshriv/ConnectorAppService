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
        private static readonly List<SearchableItem> allItems = GetAllItems();
        private const int BatchCount = 5;

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
        public CheckpointableItem MoveNext(int? checkPoint)
        {
            if (checkPoint.HasValue)
            {
                if (checkPoint.Value < allItems.Count)
                {
                    int count = Math.Min(BatchCount, allItems.Count - checkPoint.Value);
                    return new CheckpointableItem()
                    {
                        SearchableItems = allItems.GetRange(checkPoint.Value, count),
                        Checkpoint = Math.Min(checkPoint.Value + count, allItems.Count),
                        MoveNext = checkPoint.Value + count < allItems.Count,
                    };
                }
                else
                {
                    return new CheckpointableItem()
                    {
                        Checkpoint = allItems.Count,
                        MoveNext = false,
                    };
                }
            }
            else
            {
                return new CheckpointableItem()
                {
                    SearchableItems = allItems.GetRange(0, BatchCount),
                    Checkpoint = BatchCount,
                    MoveNext = BatchCount < allItems.Count,
                };
            }
        }

        private static List<SearchableItem> GetAllItems()
        {
            var items = new List<SearchableItem>();

            for (var i = 0; i < 12; i++)
            {
                items.Add(new SearchableItem()
                {
                    Id = i.ToString(),
                    Properties = new Dictionary<string, object>()
                    {
                        {"firstname", "firstname" + i.ToString()},
                        {"lastname", "lastname" +  i.ToString()},
                    }
                }); ;
            }

            return items;
        }
    }
}