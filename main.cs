using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace RiotAPIwrapper
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("asd");
        }
    }

        public class Api
    {
        private string API_KEY;

        public Api(string API_KEY)
        {
            this.API_KEY = API_KEY;
        }




        public Summoner_V4 GetSummonerInfo(string region, string summonerName)
        {
            using (var webClient = new WebClient())
            {
                String json = webClient.DownloadString($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summonerName}?api_key={this.API_KEY}");
                Summoner_V4 jsonconverted = JsonConvert.DeserializeObject<Summoner_V4>(json);
                return jsonconverted;
            }
        }

        public League_V4[] GetRankedInfo(string region, string summonerID)
        {
            using (var webClient = new WebClient())
            {
                String json = webClient.DownloadString($"https://{region}.api.riotgames.com/lol/league/v4/entries/by-summoner/{summonerID}?api_key={this.API_KEY}");
                League_V4[] jsonconverted = JsonConvert.DeserializeObject<League_V4[]>(json);
                return jsonconverted;
            }
        }

        public ChampionMastery_V4[] GetChampionMastery(string region, string summonerID)
        {
            using (var webClient = new WebClient())
            {
                String json = webClient.DownloadString($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/{summonerID}?api_key={this.API_KEY}");
                ChampionMastery_V4[] jsonconverted = JsonConvert.DeserializeObject<ChampionMastery_V4[]>(json);
                return jsonconverted;
            }
        }

        public Match_V4_Matchlist GetMatchHistory(string region, string accountID)
        {
            using (var webClient = new WebClient())
            {
                String json = webClient.DownloadString($"https://{region}.api.riotgames.com/lol/match/v4/matchlists/by-account/{accountID}?api_key={this.API_KEY}");
                Match_V4_Matchlist jsonconverted = JsonConvert.DeserializeObject<Match_V4_Matchlist>(json);
                return jsonconverted;
            }
        }

        public Spectator_V4_liveMatch GetLiveMatchÍnfo(string region, string summonerID)
        {
            using (var webClient = new WebClient())
            {
                String json = webClient.DownloadString($"https://{region}.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/{summonerID}?api_key={this.API_KEY}");
                Spectator_V4_liveMatch jsonconverted = JsonConvert.DeserializeObject<Spectator_V4_liveMatch>(json);
                return jsonconverted;
            }
        }
    }

    public class Summoner_V4
    {
        public string id { get; set; }
        public string accountId { get; set; }
        public string puuid { get; set; }
        public string name { get; set; }
        public int profileIconId { get; set; }
        public long revisionDate { get; set; }
        public int summonerLevel { get; set; }
    }

    public class League_V4
    {
        public string leagueId { get; set; }
        public string queueType { get; set; }
        public string tier { get; set; }
        public string rank { get; set; }
        public string summonerId { get; set; }
        public string summonerName { get; set; }
        public int leaguePoints { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public bool veteran { get; set; }
        public bool inactive { get; set; }
        public bool freshBlood { get; set; }
        public bool hotStreak { get; set; }
    }

    public class ChampionMastery_V4
    {
        public int championId { get; set; }
        public int championLevel { get; set; }
        public int championPoints { get; set; }
        public object lastPlayTime { get; set; }
        public int championPointsSinceLastLevel { get; set; }
        public int championPointsUntilNextLevel { get; set; }
        public bool chestGranted { get; set; }
        public int tokensEarned { get; set; }
        public string summonerId { get; set; }
    }
    public class Match_V4_Matchlist_Match
    {
        public string platformId { get; set; }
        public object gameId { get; set; }
        public int champion { get; set; }
        public int queue { get; set; }
        public int season { get; set; }
        public object timestamp { get; set; }
        public string role { get; set; }
        public string lane { get; set; }
    }

    public class Match_V4_Matchlist
    {
        public List<Match_V4_Matchlist_Match> matches { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public int totalGames { get; set; }
    }

    public class Spectator_V4_liveMatch_Perks
    {
        public List<long> perkIds { get; set; }
        public long perkStyle { get; set; }
        public long perkSubStyle { get; set; }
    }

    public class Spectator_V4_liveMatch_Participant
    {
        public long teamId { get; set; }
        public long spell1Id { get; set; }
        public long spell2Id { get; set; }
        public long championId { get; set; }
        public long profileIconId { get; set; }
        public string summonerName { get; set; }
        public bool bot { get; set; }
        public string summonerId { get; set; }
        public List<object> gameCustomizationObjects { get; set; }
        public Spectator_V4_liveMatch_Perks perks { get; set; }
    }

    public class Spectator_V4_liveMatch_Observers
    {
        public string encryptionKey { get; set; }
    }

    public class Spectator_V4_liveMatch_BannedChampion
    {
        public long championId { get; set; }
        public long teamId { get; set; }
        public long pickTurn { get; set; }
    }

    public class Spectator_V4_liveMatch
    {
        public long gameId { get; set; }
        public long mapId { get; set; }
        public string gameMode { get; set; }
        public string gameType { get; set; }
        public long gameQueueConfigId { get; set; }
        public List<Spectator_V4_liveMatch_Participant> participants { get; set; }
        public Spectator_V4_liveMatch_Observers observers { get; set; }
        public string platformId { get; set; }
        public List<Spectator_V4_liveMatch_BannedChampion> bannedChampions { get; set; }
        public long gameStartTime { get; set; }
        public long gameLength { get; set; }
    }


}
