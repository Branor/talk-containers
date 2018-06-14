using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Mvc;
using StatsN;

namespace webapi.Controllers
{
    public class HomeController : Controller
    {
        private IStatsd stats;

        public HomeController(IStatsd stats) {
            this.stats = stats;
        }

        [HttpGet("/")]
        public async Task<string> Get()
        {
            await stats.CountAsync("get"); // Aggregated metrics
            await stats.CountAsync($"{System.Environment.MachineName}.get"); // Contaner metric
            
            return $"[FROM: {System.Environment.MachineName}]: Hello world!";
        }

        [HttpGet("/{id}")]
        public async Task<string> Get(int id)
        {
            // Might be a bad idea, metric with high cardinality.
            await stats.CountAsync($"get.{id}");
            // Almost certainly a bad idea, very high cardinality!
            await stats.CountAsync($"{System.Environment.MachineName}.get.{id}");

            return $"[FROM: {System.Environment.MachineName}]: Let's play Good Idea - Bad Idea!";
        }
    }
}
