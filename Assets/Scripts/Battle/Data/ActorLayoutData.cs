using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public class ActorLayoutData
    {
        public List<ActorPositionData> ActorDataList { get; }

        public BattleHeroData HeroData { get; }

        public ActorLayoutData(List<ActorPositionData> actorDataList, BattleHeroData heroData)
        {
            ActorDataList = actorDataList;
            HeroData = heroData;
        }
    }
}