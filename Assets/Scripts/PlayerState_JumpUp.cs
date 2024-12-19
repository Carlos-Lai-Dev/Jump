using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerState/JumpUp", fileName = "PlayerState_JumpUp")]
public class PlayerState_JumpUp : PlayerState
{
    [SerializeField] private float moveSpeedInAir;
    [SerializeField] private float jumpForce;
    public override void Enter()
    {
        base.Enter();
        playerController.SetVelocity_Y(jumpForce);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (playerInput.notJump || playerController.IsFalling)
        { 
            playerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        playerController.Move(moveSpeedInAir);
    }
}
