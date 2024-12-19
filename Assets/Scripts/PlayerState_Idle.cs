using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        
    }
    public override void LogicUpdate()
    {

        if (playerInput.isMove)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Run));
        }

        if (playerInput.isJump)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

        if (!playerController.IsGround)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicUpdate()
    {


    }
}
