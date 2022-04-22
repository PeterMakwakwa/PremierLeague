using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PremierLeague.Core;
using PremierLeague.Models;
using PremierLeague.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostingEnvironment Environment;
        private readonly IPremierLeagueTeamService iPremierLeagueTeamService;

        public HomeController(ILogger<HomeController> logger
                              ,IHostingEnvironment _environment
                              ,IPremierLeagueTeamService iPremierLeagueTeamService)
        {
            _logger = logger;
            Environment = _environment;
            this.iPremierLeagueTeamService = iPremierLeagueTeamService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile postedFile)
        {
            int counter = 1;
            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
            var stringJsonArray  = iPremierLeagueTeamService.GetJsonConvertedFromCsv(Utils.getPath(path, postedFile));

            var PremierLeagueLogTable = iPremierLeagueTeamService.PreparingLogTableData(stringJsonArray);
            var SortedPremierLeagueLogTable = iPremierLeagueTeamService.TeamsSortedByHighestPoints(PremierLeagueLogTable);
            var teamRanked = iPremierLeagueTeamService.TeamsRanking(SortedPremierLeagueLogTable, counter);

             DataTable dataTable= ListtoDataTableConverter.ToDataTable(teamRanked);           
            return View(dataTable);
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
