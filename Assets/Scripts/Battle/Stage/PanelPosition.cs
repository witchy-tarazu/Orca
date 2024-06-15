namespace Orca
{
#pragma warning disable CS0661 // �^�͉��Z�q == �܂��͉��Z�q != ���`���܂����AObject.GetHashCode() ���I�[�o�[���C�h���܂���
#pragma warning disable CS0660 // �^�͉��Z�q == �܂��͉��Z�q != ���`���܂����AObject.Equals(object o) ���I�[�o�[���C�h���܂���
    public struct PanelPosition
#pragma warning restore CS0660 // �^�͉��Z�q == �܂��͉��Z�q != ���`���܂����AObject.Equals(object o) ���I�[�o�[���C�h���܂���
#pragma warning restore CS0661 // �^�͉��Z�q == �܂��͉��Z�q != ���`���܂����AObject.GetHashCode() ���I�[�o�[���C�h���܂���
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