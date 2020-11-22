using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NRatings.Client.ApiClient;
using NRatings.Client.ApiClient.DTO;
using NRatings.Client.Domain;
using Car = NRatings.Client.Domain.Car;
using Driver = NRatings.Client.Domain.Driver;
using DriverRaceData = NRatings.Client.Domain.DriverRaceData;
using Race = NRatings.Client.Domain.Race;
using RaceResult = NRatings.Client.Domain.RaceResult;
using RaceState = NRatings.Client.Domain.RaceState;
using Season = NRatings.Client.Domain.Season;
using Series = NRatings.Client.Domain.Series;
using Track = NRatings.Client.Domain.Track;
using TrackType = NRatings.Client.Domain.TrackType;

namespace NRatings.Client.Business
{
    public class RRDataFetcher
    {
        private NRatingsApiClient nratingsApiClient;

        public RRDataFetcher()
        {
            var apiSettings = new APIClientSettings(Properties.Settings.Default.ApiBaseUri);
            this.nratingsApiClient = new NRatingsApiClient(apiSettings);
        }

        public async Task<IList<TrackType>> GetTrackTypesAsync()
        {
            try
            {
                var dto = await this.nratingsApiClient.GetTrackTypesAsync();

                return dto.Select(tt => new TrackType()
                {
                    Id = tt.Id,
                    Name = tt.Name,
                    Description = tt.Description
                }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IList<Series>> GetSeriesAsync()
        {

            try
            {
                var dto = await this.nratingsApiClient.GetSeriesAsync();

                return dto.Select(s => new Series()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Seasons = s.Seasons.Select(se => new Season()
                    {
                        Id = se.Id,
                        Name = se.Name,
                        SeriesId = se.SeriesId
                    }).ToList()
                }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IList<Race>> GetRacesAsync(Season season)
        {
            try
            {
                var dto = await this.nratingsApiClient.GetRacesAsync(season.Id);

                return dto.Select(r => new Race()
                {
                    Id = r.Id,
                    Season = season,
                    RaceName = r.RaceName,
                    RaceDate = r.RaceDate,
                    Track = new Track() { Id = r.TrackId, Name = r.TrackName },
                    TrackTypeId = r.TrackTypeId,
                    NR2003TrackTypeId = r.NR2003TrackTypeId
                }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Race> GetRaceDetailsAsync(Race race)
        {
            try
            {
                var raceIds = new List<int>();
                raceIds.Add(race.Id);

                var dto = await this.nratingsApiClient.GetRacesDetailsAsync(raceIds);

                Race result = race;

                IList<Driver> drivers = dto.Drivers.Select(d => new Driver()
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToList();

                IList<Car> cars = dto.Cars.Select(d => new Car()
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToList();

                IList<RaceState> raceStates = dto.RaceStates.Select(rs => new RaceState()
                {
                    Id = rs.Id,
                    Name = rs.Name,
                    IsDNFMechanical = rs.IsDNFMechanical,
                    IsDNFCrash = rs.IsDNFCrash
                }).ToList();

                race.RaceResults = dto.RaceResults.Select(rr => this.ToDomainRaceResult(rr, drivers, cars, raceStates)).ToList();
                race.PitStopDatas = dto.RacePitStopDataList.Select(p => this.ToDomainPitStopData(p, drivers, new List<Race>(){ race })).ToList();
                race.LoopDatas = dto.RaceLoopDataList.Select(l => this.ToDomainLoopData(l, drivers, new List<Race>(){ race })).ToList();
                
                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IList<DriverRaceData>> GetDriverRaceDataAsync(List<Race> raceList)
        {
            try
            {
                IList<int> raceIds = raceList.Select(r => r.Id).ToList();
                var dto = await this.nratingsApiClient.GetRacesDetailsAsync(raceIds);

                IList<DriverRaceData> result = new List<DriverRaceData>();

                IList<TrackType> trackTypes = dto.TrackTypes.Select(tt => new TrackType()
                {
                    Id = tt.Id,
                    Name = tt.Name,
                    Description = tt.Description
                }).ToList();

                IList<Track> tracks = dto.Tracks.Select(t => new Track()
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList();

                IList<Race> races = dto.Races.Select(r => new Race()
                {
                    Id = r.Id,
                    RaceName = r.RaceName,
                    RaceDate = r.RaceDate,
                    Track = tracks.FirstOrDefault(t => t.Id == r.TrackId),
                    TrackTypeId = r.TrackTypeId,
                    NR2003TrackTypeId = r.NR2003TrackTypeId
                }).ToList();

                IList<Driver> drivers = dto.Drivers.Select(d => new Driver()
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToList();

                IList<Car> cars = dto.Cars.Select(d => new Car()
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToList();

                IList<RaceState> raceStates = dto.RaceStates.Select(rs => new RaceState()
                {
                    Id = rs.Id,
                    Name = rs.Name,
                    IsDNFMechanical = rs.IsDNFMechanical,
                    IsDNFCrash = rs.IsDNFCrash
                }).ToList();


                result = dto.RaceResults.Select(rr => new DriverRaceData()
                {
                    Race = races.FirstOrDefault(r => r.Id == rr.RaceId),
                    Driver = drivers.FirstOrDefault(d => d.Id == rr.DriverId),
                    Car = cars.FirstOrDefault(c => c.Id == rr.CarId),
                    RaceResult = this.ToDomainRaceResult(rr, drivers, cars, raceStates),
                    PitStopData = this.ToDomainPitStopData(dto.RacePitStopDataList.FirstOrDefault(p => p.RaceId == rr.RaceId && p.DriverId == rr.DriverId), drivers, races),
                    LoopData = this.ToDomainLoopData(dto.RaceLoopDataList.FirstOrDefault(l => l.RaceId == rr.RaceId && l.DriverId == rr.DriverId), drivers, races)
                }).ToList();

                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        private RaceResult ToDomainRaceResult(ApiClient.DTO.RaceResult rr, IList<Driver> drivers, IList<Car> cars, IList<RaceState> raceStates)
        {
            if (rr != null)
            {
                return new RaceResult()
                {
                    Id = rr.Id,
                    Driver = drivers.FirstOrDefault(d => d.Id == rr.DriverId),
                    Car = cars.FirstOrDefault(c => c.Id == rr.CarId),
                    CarNumber = rr.CarNumber,
                    Laps = rr.Laps,
                    LapsLed = rr.LapsLed,
                    FinishPosition = rr.FinishPosition,
                    StartPosition = rr.StartPosition,
                    RaceState = raceStates.FirstOrDefault(rs => rs.Id == rr.RaceStateId)
                };
            }

            return null;
        }

        private PitStopData ToDomainPitStopData(RacePitStopData dto, IList<Driver> drivers, IList<Race> races)
        {
            if (dto != null)
            {
                return new PitStopData()
                {
                    Id = dto.Id,
                    Driver = drivers.FirstOrDefault(d => d.Id == dto.DriverId),
                    Race = races.FirstOrDefault(r => r.Id == dto.RaceId),
                    NrOfStops = dto.NrOfStops,
                    AverageTime = dto.AverageTime,
                    TotalTime = dto.TotalTime,
                    InGarage = dto.InGarage
                };
            }

            return null;
        }

        private LoopData ToDomainLoopData(RaceLoopData dto, IList<Driver> drivers, IList<Race> races)
        {
            if (dto != null)
            {
                return new LoopData()
                {
                    Id = dto.Id,
                    Driver = drivers.FirstOrDefault(d => d.Id == dto.DriverId),
                    Race = races.FirstOrDefault(r => r.Id == dto.RaceId),
                    AveragePosition = dto.AveragePosition,
                    FastestLaps = dto.FastestLaps,
                    GreenFlagPassed = dto.GreenFlagPassed,
                    GreenFlagPasses = dto.GreenFlagPasses,
                    HighestPosition = dto.HighestPosition,
                    LowestPosition = dto.LowestPosition,
                    MidRacePosition = dto.MidRacePosition,
                    QualityPasses = dto.QualityPasses,
                    Top15Laps = dto.Top15Laps,
                    Rating = dto.Rating
                };
            }

            return null;
        }
    }
}
