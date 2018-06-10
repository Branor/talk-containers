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

        // GET /
        [HttpGet("test")]
        public async Task<string> Get()
        {
            await stats.CountAsync("get");
            return $"[FROM: {System.Environment.MachineName}]: Hello world!";
        }

        // GET /5 
        [HttpGet("test/{id}")]
        public async Task<string> Get(int id)
        {
            await stats.CountAsync($"get.{id}"); // Terrible idea, don't generate metrics with high cardinality!
            return $"[FROM: {System.Environment.MachineName}]: Let's play Good Idea - Bad Idea!";
        }

        // GET /5 
        [HttpGet("docker/{id}")]
        public async Task<string> GetMachine(int id)
        {
            await stats.CountAsync($"get.{System.Environment.MachineName}.{id}");
            return $"[FROM: {System.Environment.MachineName}]: You get a container, and you get a container, everybody gets a container!";
        }
    }
}
