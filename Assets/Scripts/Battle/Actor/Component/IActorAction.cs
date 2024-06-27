using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orca
{
    public interface IActorAction
    {
        ActorComponentState CurrentState { get; }
    }
}