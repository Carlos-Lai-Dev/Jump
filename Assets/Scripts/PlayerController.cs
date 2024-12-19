using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Rigidbody player_Rb;
    private PlayerInput playerInput;
    private PlayerGroundDetector playerGroundDetector;

    public bool IsGround => playerGroundDetector.IsGrounded;
    public bool IsFalling => player_Rb.velocity.y < 0 && !IsGround;
    private void Awake()
    {
        player_Rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        playerGroundDetector = GetComponentInChildren<PlayerGroundDetector>();
    }
    private void Start()
    {
        playerInput.EnablePlayerInput();
    }
    public void ClearVelocity()
    {
        player_Rb.velocity = Vector2.zero;
    }
    public void Move(float speed)
    {
        if (playerInput.isMove)
            transform.localScale = new Vector3(playerInput.axis_X, 1f, 1f);

        SetVelocity_X(speed * playerInput.axis_X);
    }

    public void SetVelocity_X(float speed)
    {
        player_Rb.velocity = new Vector2(speed, player_Rb.velocity.y);
    }

    public void SetVelocity_Y(float speed)
    {
        player_Rb.velocity = new Vector2(player_Rb.velocity.x, speed);
    }
}
