using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState currentState;
    protected static Dictionary<System.Type, PlayerState> States_Dic;
    private void Update()
    {
        currentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        currentState.PhysicUpdate();
    }

    protected void EnterState(IState newState)
    {

        currentState = newState;
        currentState.Enter();
    }
    protected void EnterState(System.Type newType)
    {

        EnterState(States_Dic[newType]);
    }

    public void SwitchState(IState newState)
    {
        currentState.Exit();
        EnterState(newState);
    }

    public void SwitchState(System.Type newType)
    {
        SwitchState(States_Dic[newType]);
    }
}
