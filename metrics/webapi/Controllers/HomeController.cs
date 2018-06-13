using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet("application")]
        public async Task<string> Get()
        {
            await stats.CountAsync("get");
            return $"[FROM: {System.Environment.MachineName}]: Hello world!";
        }

        [HttpGet("application/{id}")]
        public async Task<string> Get(int id)
        {
            // Probably a bad idea, metric with high cardinality!
            await stats.CountAsync($"get.{id}"); 
            return $"[FROM: {System.Environment.MachineName}]: Let's play Good Idea - Bad Idea!";
        }

        [HttpGet("container")]
        public async Task<string> GetMachine()
        {
            await stats.CountAsync($"{System.Environment.MachineName}.get");
            return $"[FROM: {System.Environment.MachineName}]: You get a container, and you get a container, everybody gets a container!";
        }

        [HttpGet("container/{id}")]
        public async Task<string> GetMachine(int id)
        {
            // Terrible idea, metric with very high cardinality!
            await stats.CountAsync($"{System.Environment.MachineName}.get.{id}");
            return $"[FROM: {System.Environment.MachineName}]: So many metrics! You'll get tired of metrics!";
        }
    }
}
