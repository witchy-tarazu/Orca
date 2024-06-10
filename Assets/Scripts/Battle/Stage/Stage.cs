using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class Stage
    {
        private int WidthPerPanel { get; set; }

        private Panel[] Panels { get; set; }

        /// <summary>
        /// ステージ内か
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool IsValidPos(int pos)
        {
            return true;
        }

        /// <summary>
        /// 穴が開いているか
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool IsPitfall(int pos)
        {
            return true;
        }
    }
}