namespace Orca
{
    public readonly struct ActorPositionData
    {
        public MasterEnemy Enemy { get; }
        public PanelPosition Position { get; }

        public ActorPositionData(MasterEnemy enemy, PanelPosition position)
        {
            Enemy = enemy;
            Position = position;
        }
    }
}