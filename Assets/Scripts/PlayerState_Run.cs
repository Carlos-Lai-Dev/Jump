using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerState/Run", fileName = "PlayerState_Run")]
public class PlayerState_Run : PlayerState
{
    [SerializeField] private float player_MoveSpeed;
    public override void Enter()
    {
        base.Enter();
        
    }
    public override void Exit()
    {
        playerController.ClearVelocity();
    }
    public override void LogicUpdate()
    {
        if (!playerInput.isMove)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));
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
        playerController.Move(player_MoveSpeed);
    }
}
