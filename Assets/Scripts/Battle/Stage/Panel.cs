using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public enum PanelType
    {
        Normal,
    }

    public class Panel
    {
        public PanelType Type { get; set; }

        private List<ActorHealth> HealthList { get; set; } = new();

        public Panel(PanelType type)
        {
            Type = type;
            HealthList.Clear();
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

        public List<ActorHealth> Listup(CheckData checkData)
        {
            var healthList = new List<ActorHealth>();

            return healthList;
        }
    }
}