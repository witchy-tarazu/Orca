using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Orca
{
    public class CustomPieceLauncher : MonoBehaviour
    {
        [field: SerializeField]
        private float LaunchSpeed { get; set; } = 50.0f;

        [field: SerializeField]
        private float LaunchAngleRange { get; set; } = 15f;

        [field: SerializeField]
        private float LaunchInterval { get; set; } = 0.1f;

        [field: SerializeField]
        private GameObject LeftWall { get; set; }


        void Start()
        {

        }

        public void Launch(
            List<CustomPieceBehaviour> newPieceList,
            List<CustomPieceBehaviour> watchPieceList,
            Action onFinishLaunch)
        {
            StartCoroutine(LaunchCoroutine(newPieceList, watchPieceList, onFinishLaunch));
        }

        private IEnumerator LaunchCoroutine(
            List<CustomPieceBehaviour> pieceList,
            List<CustomPieceBehaviour> watchPieceList,
            Action onFinishLaunch)
        {
            LeftWall.SetActive(false);
            foreach (var piece in pieceList)
            {
                if (!piece.IsActive) { continue; }
                piece.transform.position = transform.position;
                piece.Launch(LaunchSpeed, LaunchAngleRange);
                yield return new WaitForSeconds(LaunchInterval);
            }
            LeftWall.SetActive(true);

            while (watchPieceList.Any(piece => piece.IsActive && !piece.IsStopped()))
            {
                yield return null;
            }

            SetDirections(pieceList);

            onFinishLaunch.Invoke();
        }

        private void SetDirections(List<CustomPieceBehaviour> pieceList)
        {
            var activeList = pieceList.Where(piece => piece.IsActive);
            foreach (var piece in activeList)
            {
                piece.ResetDirections();
                var others = activeList.Where(another => another != piece);
                foreach (var another in others)
                {
                    SetDirection(piece, another);
                }
            }
        }

        private void SetDirection(CustomPieceBehaviour src, CustomPieceBehaviour dest)
        {
            var piecePos = src.transform.localPosition;
            var anotherPos = dest.transform.localPosition;
            var diff = anotherPos - piecePos;
            var angle = Mathf.Atan2(diff.x, diff.y);

            // è„ï˚å¸
            if (45 < angle && angle <= 135)
            {
                if (src.UpPiece == null)
                {
                    src.UpPiece = dest;
                    return;
                }

                var current = src.UpPiece.transform.position - piecePos;
                if (diff.magnitude < current.magnitude)
                {
                    src.UpPiece = dest;
                }
                return;
            }

            // â∫ï˚å¸
            if (-135 < angle && angle <= -45)
            {
                if (src.DownPiece == null)
                {
                    src.DownPiece = dest;
                    return;
                }

                var current = src.DownPiece.transform.position - piecePos;
                if (diff.magnitude < current.magnitude)
                {
                    src.DownPiece = dest;
                }
                return;
            }

            // ç∂ï˚å¸
            if (-180 < angle && angle <= -135
                || 135 < angle && angle <= 180)
            {
                if (src.LeftPiece == null)
                {
                    src.LeftPiece = dest;
                    return;
                }

                var current = src.LeftPiece.transform.position - piecePos;
                if (diff.magnitude < current.magnitude)
                {
                    src.LeftPiece = dest;
                }
                return;
            }

            // âEï˚å¸
            if (-45 < angle && angle <= 45)
            {
                if (src.RightPiece == null)
                {
                    src.RightPiece = dest;
                    return;
                }

                var current = src.RightPiece.transform.position - piecePos;
                if (diff.magnitude < current.magnitude)
                {
                    src.RightPiece = dest;
                }
                return;
            }
        }
    }
}