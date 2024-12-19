using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerState/Land", fileName = "PlayerState_Land")]
public class PlayerState_Land : PlayerState
{
    [SerializeField] private float stiffTime;
    public override void Enter()
    {
        base.Enter();
        playerController.ClearVelocity();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (playerInput.isJump)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

        if(StateDuration < stiffTime) return;

        if (playerInput.isMove)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Run));
        }

        if (IsAnimationFinished)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }
}
