namespace Orca
{
    public interface IHitChecker
    {
        int Grade { get; }

        void Hit(HitData data);
    }
}