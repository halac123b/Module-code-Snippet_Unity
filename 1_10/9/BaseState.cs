using System;

public abstract class BaseState<EState> where EState : Enum
{
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EState GetNextState();
    public abstract void OnTriggerEnter();
    public abstract void OnTriggerStay();
    public abstract void OnTriggerExit();
}
