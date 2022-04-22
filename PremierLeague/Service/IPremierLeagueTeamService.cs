using Microsoft.AspNetCore.Http;
using PremierLeague.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Service
{
    public interface IPremierLeagueTeamService
    {
        List<Dto> PreparingLogTableData(string jsonArray);
        List<Dto> TeamsSortedByHighestPoints(List<Dto> teams);
        string GetJsonConvertedFromCsv(string path);
        List<Dto> TeamsRanking(List<Dto> teams, int counter);
    }
}
