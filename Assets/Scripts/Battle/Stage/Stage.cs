using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class Stage
    {
        private int widthPerPanel { get; set; }

        private List<Panel> panels = new();

        /// <summary>
        /// �X�e�[�W����
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool IsValidPos(int pos)
        {
            return true;
        }

        /// <summary>
        /// �����J���Ă��邩
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool IsPitfall(int pos)
        {
            return true;
        }
    }
}