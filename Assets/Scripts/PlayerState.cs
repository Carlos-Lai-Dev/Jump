using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    [SerializeField] private string stateName;
    [SerializeField,Range(0,1)] private float transitionDuration = 0.1f;
    private int stateHash;

    protected Animator animator;
    protected PlayerInput playerInput;
    protected PlayerController playerController;
    protected PlayerStateMachine playerStateMachine;
    private void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }

    public void InitState(Animator animator, PlayerStateMachine playerStateMachine, PlayerInput playerInput, PlayerController playerController)
    {
        this.animator = animator;
        this.playerInput = playerInput;
        this.playerController = playerController;
        this.playerStateMachine = playerStateMachine;
    }
    public virtual void Enter()
    {
        animator.CrossFade(stateHash,transitionDuration);
    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicUpdate()
    {

    }


}
