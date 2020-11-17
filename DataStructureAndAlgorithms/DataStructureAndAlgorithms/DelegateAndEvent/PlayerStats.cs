using System;
namespace DataStructureAndAlgorithms.DelegateAndEvent
{
    public struct PlayerStats
    {
        public string name;
        public int kills;
        public int deaths;
        public int flagsCaptured;

        //self-defined constructor needs to initialize all the properties 
        public PlayerStats(string _name, int _kills, int _deaths, int _flagsCaptured)
        {
            name = _name;
            kills = _kills;
            deaths = _deaths;
            flagsCaptured = _flagsCaptured;
        }
    }
}
