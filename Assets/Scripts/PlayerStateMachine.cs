using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    private Animator animator;
    private PlayerInput playerInput;
    private PlayerController playerController;
    [SerializeField] private PlayerState[] playStates_Arr;
    

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        playerInput = GetComponent<PlayerInput>();
        playerController = GetComponent<PlayerController>();
        States_Dic = new Dictionary<System.Type, PlayerState>(playStates_Arr.Length);

        foreach (var state in playStates_Arr)
        {
            state.InitState(animator, this,playerInput, playerController);
            States_Dic.Add(state.GetType(), state);
        }
    }

    private void Start()
    {
        EnterState(typeof(PlayerState_Idle));
    }


}
