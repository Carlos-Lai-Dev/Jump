using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody player_Rb;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        player_Rb = GetComponent<Rigidbody>();

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
        if(playerInput.isMove)
        transform.localScale = new Vector3(playerInput.axis_X,1f,1f);

        SetVelocity_X(speed * playerInput.axis_X);
    }

    public void SetVelocity_X(float speed)
    {
        player_Rb.velocity = new Vector2(speed, player_Rb.velocity.y);
    }
}
