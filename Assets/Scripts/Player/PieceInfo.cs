using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class PieceInfo
    {
        public MasterPieceRelation Master { get; private set; }
        public int Stock { get; private set; }

        public PieceInfo(MasterPieceRelation master, int stock)
        {
            Master = master;
            Stock = stock;
        }

        public void AddStock(int addition) => Stock += addition;

        public void RemoveStock(int removeition) => Stock -= removeition;
    }
}