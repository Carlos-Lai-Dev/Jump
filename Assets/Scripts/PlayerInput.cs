using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player_InputAction player_InputAction;

    private Vector2 axes => player_InputAction.Player.PlayerMove.ReadValue<Vector2>();
    public bool isJump => player_InputAction.Player.PlayerJump.WasPressedThisFrame();
    public bool notJump => player_InputAction.Player.PlayerJump.WasReleasedThisFrame();
    public bool isMove => axis_X != 0;
    public float axis_X => axes.x;
    
    private void Awake()
    {
        player_InputAction = new Player_InputAction();
    }

    public void EnablePlayerInput()
    {
        player_InputAction.Player.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }
}
