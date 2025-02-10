using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> Status = new();
    protected BaseState<EState> CurrentState;

    void Start()
    {
        CurrentState.EnterState();
    }

    void Update()
    {
        EState nextStateKey = CurrentState.GetNextState();
        if (nextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.UpdateState();
        }

    }

    prvivate void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnter(other);
    }
    prvivate void OnTriggerStay(Collider other)
    {
        CurrentState.OnTriggerStay(other);
    }
    prvivate void OnTriggerExit(Collider other)
    {
        CurrentState.OnTriggerExit(other);
    }
}
