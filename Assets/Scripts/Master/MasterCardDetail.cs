using MasterMemory;
using MessagePack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    [MemoryTable("card_detail"), MessagePackObject(true)]
    public class MasterCardDetail : MonoBehaviour
    {
        public MasterCardDetail(int cardId, int influenceId, int executeFrame)
        {
            CardId = cardId;
            InfluenceId = influenceId;
            ExecuteFrame = executeFrame;
        }

        [PrimaryKey(0)]
        [SecondaryKey(0), NonUnique]
        public int CardId { get; }

        [PrimaryKey(1)]
        public int InfluenceId { get; }

        public int ExecuteFrame { get; }
    }
}