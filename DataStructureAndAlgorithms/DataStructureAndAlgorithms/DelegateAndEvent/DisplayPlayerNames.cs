using System;
namespace DataStructureAndAlgorithms.DelegateAndEvent
{
    public class DisplayPlayerNames
    {
        delegate int ScoreDelegate(PlayerStats stats);
        public DisplayPlayerNames()
        {
        }

        public PlayerStats getPlayStatusOfMostKills(PlayerStats[] allPlayerStats)
        {
            return GetPlayerStatsTopScore(allPlayerStats, stats => stats.kills);
        }

        public PlayerStats getPlayStatusOfMostFlagsCaptured(PlayerStats[] allPlayerStats)
        {
            return GetPlayerStatsTopScore(allPlayerStats, stats => stats.flagsCaptured);
        }

        private PlayerStats GetPlayerStatsTopScore(PlayerStats[] allPlayerStats, ScoreDelegate scoreCalculator)
        {
            int topScoreIndex = 0;
            int i = 0;
            int bestScore = 0;
            foreach (PlayerStats stats in allPlayerStats)
            {
                int score = scoreCalculator(stats);
                if (score > bestScore)
                {
                    bestScore = score;
                    topScoreIndex = i;
                }
                i++;
            }
            return allPlayerStats[topScoreIndex];
        }
    }
}
