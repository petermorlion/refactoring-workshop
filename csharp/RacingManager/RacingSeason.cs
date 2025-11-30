namespace RacingManager
{
    public class RacingSeason
    {
        public IDictionary<Guid, string> Races { get; init; } = new Dictionary<Guid, string>();
        public IDictionary<Guid, string> Racers { get; init; } = new Dictionary<Guid, string>();
        public IDictionary<(Guid raceId, Guid racerId), int> Positions { get; init; } = new Dictionary<(Guid, Guid), int>();

        public Guid AddRace(string raceName)
        {
            var raceId = Guid.NewGuid();
            Races.Add(raceId, raceName);
            return raceId;
        }

        public Guid AddRacer(string racerName, bool isAI)
        {
            var racerId = Guid.NewGuid();
            if (isAI)
            {
                racerName = $"{racerName} [AI]";
            }

            Racers.Add(racerId, racerName);
            return racerId;
        }

        public void AddResult(Guid raceId, Guid racerId, int position)
        {
            Positions[(raceId, racerId)] = position;
        }

        public IList<(string raceName, int position)> GetRacerPositions(Guid racerId)
        {
            var results = new List<(string raceName, int position)>();
            foreach (var position in Positions)
            {
                if (position.Key.racerId == racerId)
                {
                    results.Add((Races[position.Key.raceId], position.Value));
                }
            }
            return results;
        }

        public IDictionary<(Guid racerId, string racerName), int> GetResults()
        {
            var results = new Dictionary<(Guid racerId, string racerName), int>();
            foreach (var racer in Racers)
            {
                var totalPoints = 0;
                foreach (var position in Positions)
                {
                    if (position.Key.racerId == racer.Key)
                    {
                        var points = 0;
                        switch (position.Value)
                        {
                            case 1:
                                points = 25;
                                break;
                            case 2:
                                points = 18;
                                break;
                            case 3:
                                points = 15;
                                break;
                            case 4:
                                points = 12;
                                break;
                            case 5:
                                points = 10;
                                break;
                            case 6:
                                points = 8;
                                break;
                            case 7:
                                points = 6;
                                break;
                            case 8:
                                points = 4;
                                break;
                            case 9:
                                points = 2;
                                break;
                            case 10:
                                points = 1;
                                break;
                        }

                        totalPoints += points;
                    }
                }
                results[(racer.Key, racer.Value)] = totalPoints;
            }

            return results.OrderByDescending(x => x.Value).ToDictionary();
        }
    }
}