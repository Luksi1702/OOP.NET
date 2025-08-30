using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using ClassesLibrary.Helpers;

namespace ClassesLibrary.Models
{
    public partial class Match
    {
        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("fifa_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? FifaId { get; set; }

        [JsonProperty("weather")]
        public Weather? Weather { get; set; }

        [JsonProperty("attendance")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Attendance { get; set; }

        [JsonProperty("officials")]
        public List<string>? Officials { get; set; }

        [JsonProperty("stage_name")]
        public string StageName { get; set; }

        [JsonProperty("home_team_country")]
        public string HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public string AwayTeamCountry { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset? Datetime { get; set; }

        [JsonProperty("winner")]
        public string Winner { get; set; }

        [JsonProperty("winner_code")]
        public string WinnerCode { get; set; }

        [JsonProperty("home_team")]
        public MatchTeam HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public MatchTeam AwayTeam { get; set; }

        [JsonProperty("home_team_events")]
        public List<TeamEvent> HomeTeamEvents { get; set; }

        [JsonProperty("away_team_events")]
        public List<TeamEvent> AwayTeamEvents { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatistics HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatistics AwayTeamStatistics { get; set; }

        [JsonProperty("last_event_update_at")]
        public DateTimeOffset? LastEventUpdateAt { get; set; }

        [JsonProperty("last_score_update_at")]
        public object LastScoreUpdateAt { get; set; }

    }


    public partial class MatchTeam
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("goals")]
        public long? Goals { get; set; }

        [JsonProperty("penalties")]
        public long? Penalties { get; set; }
    }

    public partial class TeamEvent
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("type_of_event")]
        public string? TypeOfEvent { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }

    public partial class TeamStatistics
    {
        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("attempts_on_goal")]
        public long? AttemptsOnGoal { get; set; }

        [JsonProperty("on_target")]
        public long? OnTarget { get; set; }

        [JsonProperty("off_target")]
        public long? OffTarget { get; set; }

        [JsonProperty("blocked")]
        public long? Blocked { get; set; }

        [JsonProperty("woodwork")]
        public long? Woodwork { get; set; }

        [JsonProperty("corners")]
        public long? Corners { get; set; }

        [JsonProperty("offsides")]
        public long? Offsides { get; set; }

        [JsonProperty("ball_possession")]
        public long? BallPossession { get; set; }

        [JsonProperty("pass_accuracy")]
        public long? PassAccuracy { get; set; }

        [JsonProperty("num_passes")]
        public long? NumPasses { get; set; }

        [JsonProperty("passes_completed")]
        public long? PassesCompleted { get; set; }

        [JsonProperty("distance_covered")]
        public long? DistanceCovered { get; set; }

        [JsonProperty("balls_recovered")]
        public long? BallsRecovered { get; set; }

        [JsonProperty("tackles")]
        public long? Tackles { get; set; }

        [JsonProperty("clearances")]
        public long? Clearances { get; set; }

        [JsonProperty("yellow_cards")]
        public long? YellowCards { get; set; }

        [JsonProperty("red_cards")]
        public long? RedCards { get; set; }

        [JsonProperty("fouls_committed")]
        public long? FoulsCommitted { get; set; }

        [JsonProperty("tactics")]
        public string? Tactics { get; set; }

        [JsonProperty("starting_eleven")]
        public List<StartingEleven>? StartingEleven { get; set; }

        [JsonProperty("substitutes")]
        public List<StartingEleven>? Substitutes { get; set; }
    }

    public partial class StartingEleven
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long? ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string? Position { get; set; }
    }

    public partial class Weather
    {
        [JsonProperty("humidity")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Humidity { get; set; }

        [JsonProperty("temp_celsius")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? TempCelsius { get; set; }

        [JsonProperty("temp_farenheit")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? TempFarenheit { get; set; }

        [JsonProperty("wind_speed")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? WindSpeed { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
