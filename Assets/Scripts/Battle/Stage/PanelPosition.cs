namespace Orca
{
#pragma warning disable CS0661 // 型は演算子 == または演算子 != を定義しますが、Object.GetHashCode() をオーバーライドしません
#pragma warning disable CS0660 // 型は演算子 == または演算子 != を定義しますが、Object.Equals(object o) をオーバーライドしません
    public struct PanelPosition
#pragma warning restore CS0660 // 型は演算子 == または演算子 != を定義しますが、Object.Equals(object o) をオーバーライドしません
#pragma warning restore CS0661 // 型は演算子 == または演算子 != を定義しますが、Object.GetHashCode() をオーバーライドしません
    {
        public int PositionX { get; private set; }

        public PanelPosition(int positionX)
        {
            PositionX = positionX;
        }

        public readonly bool Equals(PanelPosition other) => other.PositionX == PositionX;

        public static bool operator ==(PanelPosition left, PanelPosition right) => left.Equals(right);
        public static bool operator !=(PanelPosition left, PanelPosition right) => !(left == right);
    }
}