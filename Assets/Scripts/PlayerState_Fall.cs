using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerState/Fall", fileName = "PlayerState_Fall")]

public class PlayerState_Fall : PlayerState
{
    [SerializeField] private float moveSpeedInAir;
    [SerializeField] private AnimationCurve speedCurve;

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (playerController.IsGround)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Land));
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        playerController.Move(moveSpeedInAir);
        playerController.SetVelocity_Y(speedCurve.Evaluate(StateDuration));
    }
   
}
