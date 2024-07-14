using System.Linq;
using UnityEngine;

namespace Orca
{
    public class CustomPieceBehaviour : MonoBehaviour
    {
        [field: SerializeField]
        private Rigidbody Rigidbody { get; set; }

        [field: SerializeField]
        private SpriteRenderer Sprite { get; set; }

        public bool IsActive { get; private set; } = false;

        public CustomPieceBehaviour UpPiece { get; set; }
        public CustomPieceBehaviour DownPiece { get; set; }
        public CustomPieceBehaviour LeftPiece { get; set; }
        public CustomPieceBehaviour RightPiece { get; set; }

        public MasterPiece Master { get; private set; }
        private MemoryDatabase Database { get; set; }

        public int Grade { get; private set; }

        public void Setup(MasterPiece master, MemoryDatabase database)
        {
            Master = master;
            Database = database;

            IsActive = true;
            ResetDirections();

            Grade = Database.MasterPieceRelationTable.FindByPieceId(Master.PieceId)
                .Min(piece => piece.Grade);

            Sprite.sprite = Resources.Load<Sprite>(string.Format("Sprites/Piece/icon_piece_{0}", Master.PieceId));
            gameObject.SetActive(true);
        }

        public void Invalidate()
        {
            IsActive = false;
            gameObject.SetActive(false);
        }

        public void Launch(float speed, float angle)
        {
            float randomAngle = Random.Range(-angle, angle);
            Rigidbody.AddForce(Quaternion.Euler(0, 0, randomAngle) * Vector3.right * speed, ForceMode.Impulse);
        }

        public bool IsStopped() => Rigidbody.IsSleeping();

        public void LevelUp() => Grade++;

        public void ResetDirections() => UpPiece = DownPiece = LeftPiece = RightPiece = null;

        public bool CanLevelUp()
        {
            int maxGrade = Grade = Database.MasterPieceRelationTable.FindByPieceId(Master.PieceId)
                .Max(piece => piece.Grade);
            return maxGrade > Grade;
        }

        public bool CanMerge(CustomPieceBehaviour piece)
        {
            return Master.PieceId == piece.Master.PieceId && CanLevelUp();
        }

        public void UpdateMergeVisual(CustomPieceBehaviour mergenceSource)
        {
            if (CanMerge(mergenceSource))
            {

                return;
            }


        }

        public void UpdateLevelUpVisual(bool isMergeDisplayed)
        {
            if (CanLevelUp())
            {

                return;
            }
        }

        public void ResetVisual()
        {

        }
    }
}