using System.Collections.Generic;

namespace Orca
{
    public class BattleSystem
    {
        private List<IUpdatable> PlayerList { get; set; } = new();
        private List<IUpdatable> EnemyList { get; set; } = new();
        private List<IUpdatable> PlayerAutonomyList { get; set; } = new();
        private List<IUpdatable> EnemyAutonomyList { get; set; } = new();
    }
}