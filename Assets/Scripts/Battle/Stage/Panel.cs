using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Orca
{
    public enum PanelType
    {
        Normal,
        Hall,
    }

    public class Panel
    {
        public PanelType Type { get; set; }

        public PanelPosition Position { get; private set; }

        private List<ActorHealth> HealthList { get; set; }

        public Panel(PanelType type, PanelPosition position)
        {
            Type = type;
            Position = position;
            HealthList = new();
        }

        public bool Exists(ActorHealth health)
        {
            return HealthList.Contains(health);
        }

        public void Add(ActorHealth health)
        {
            HealthList.Add(health);
        }

        public void Remove(ActorHealth health)
        {
            HealthList.Remove(health);
        }

        public HashSet<ActorHealth> ListupHealth(CheckData checkData)
        {
            return checkData.CheckTargetType switch
            {
                InfluenceCheckRangeType.Single => new() {
                        HealthList
                        .Where(filterFunction)
                        .First()
                    },
                InfluenceCheckRangeType.Panel => HealthList
                        .Where(health => health.Side != checkData.OwnerHealth.Side)
                        .ToHashSet(),
                _ => null,
            };

            bool filterFunction(ActorHealth health)
            {
                return checkData.CheckSide switch
                {
                    InfluenceCheckSide.Whole => true,
                    InfluenceCheckSide.Owner => checkData.OwnerHealth.Side == health.Side,
                    InfluenceCheckSide.Opponent => checkData.OwnerHealth.Side != health.Side,
                    _ => false,
                };
            }
        }

        public bool HasActor(ActorHealth health)
        {
            return HealthList.Contains(health);
        }

        public bool HasAnyActor()
        {
            return HealthList.Count > 0;
        }

        public bool HasAnyActor(ActorSide side)
        {
            return HealthList.Where(health => health.Side == side).Count() > 0;
        }
    }
}