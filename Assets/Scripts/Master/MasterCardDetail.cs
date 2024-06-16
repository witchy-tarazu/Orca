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
        public MasterCardDetail(
            int cardId,
            int detailId,
            int executeFrame)
        {
            CardId = cardId;
            DetailId = detailId;
            ExecuteFrame = executeFrame;
        }

        [PrimaryKey(0)]
        [SecondaryKey(0), NonUnique]
        public int CardId { get; }

        [PrimaryKey(2)]
        public int DetailId { get; }

        public int ExecuteFrame { get; }
    }
}