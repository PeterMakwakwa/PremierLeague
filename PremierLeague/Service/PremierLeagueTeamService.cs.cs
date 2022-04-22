using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using PremierLeague.Core;
using PremierLeague.Models;
using PremierLeague.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Service
{
    public class PremierLeagueTeamService : IPremierLeagueTeamService
    {
        private readonly IPremierLeagueTeamRepository premierLeagueTeamRepository;
        public PremierLeagueTeamService(IPremierLeagueTeamRepository premierLeagueTeamRepository)
        {
            this.premierLeagueTeamRepository = premierLeagueTeamRepository;
        }

        //public PremierLeagueTeamService()
        //{

        //}
        public List<Dto> PreparingLogTableData(string jsonstring)
        {
            try
            {
                JArray jArray = JArray.Parse(jsonstring);
                List<Dto> listDto = new List<Dto>();
                foreach (var team in jArray)
                {
                    Dto dtoObject = new Dto();
                    foreach (var rounds in team)
                    {
                        var teamRound = rounds.First().ToString();

                        if (teamRound.Contains("-"))
                        {
                            var scoreSeparator = teamRound.IndexOf('-');
                            var homeTeamScore = int.Parse(teamRound.Substring(0, scoreSeparator));
                            var otherTeam = int.Parse(teamRound.Substring(scoreSeparator + 1));

                            if (homeTeamScore > otherTeam)
                            {
                                dtoObject.Points += 3;
                                dtoObject.GamesWon += 1;

                            }
                            else if (homeTeamScore < otherTeam)
                            {
                                dtoObject.Points += 0;
                                dtoObject.GamesLost += 1;
                            }
                            else
                            {
                                dtoObject.Points += 1;
                                dtoObject.GamesDrawn += 1;
                            }
                            dtoObject.GamesPlayed += 1;
                            dtoObject.GoalFor += homeTeamScore;
                            dtoObject.GoalsAgainst += otherTeam;
                            dtoObject.GoalDifference = dtoObject.GoalFor - dtoObject.GoalsAgainst;
                        }
                        else
                        {
                            dtoObject.TeamName = rounds.First().ToString();
                        }

                    }
                    listDto.Add(dtoObject);

                }
                return listDto;

            }
            catch (Exception)
            {

                throw;
            }
  
        }

        public List<Dto> TeamsSortedByHighestPoints(List<Dto> teams)
        {
             return  teams.OrderByDescending(p => p.Points)
                          .ThenByDescending(p => p.GoalDifference)
                          .ThenByDescending(p => p.GoalFor).ToList();           
           
        }       
        public string GetJsonConvertedFromCsv(string path)
        {
            return premierLeagueTeamRepository.ConvertCsvFileToJsonObject(path);
        }

        public List<Dto> TeamsRanking(List<Dto> teams,int counter)
        {
            foreach (var item in teams)
            {
                item.No = counter;
                counter++;
            }
            return teams;
        }
    }
}
