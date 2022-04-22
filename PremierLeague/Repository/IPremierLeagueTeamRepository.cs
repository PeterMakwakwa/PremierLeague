using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Repository
{
    public interface IPremierLeagueTeamRepository
    {
        string ConvertCsvFileToJsonObject(string path);
        
    }
}
