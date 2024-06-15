namespace Orca
{
    public class ActorHealth
    {
        public ActorSide Side { get; private set; }
        public ActorStatus Status { get; private set; }
        public ActorHitPoint Health { get; private set; }

        public ActorHealth(ActorSide side, ActorStatus status, ActorHitPoint health)
        {
            Side = side;
            Status = status;
            Health = health;
        }
    }
}