using UnityEngine;

public class platformerPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 5;
    public float jumpPower = 5;
    public float groundDetectLength = 1;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    bool IsGround()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position,
            transform.position + Vector3.down * groundDetectLength
            , groundLayer);
        return hit.collider != null;
    }

    void Jump()
    {
        if (!(Input.GetKeyDown(KeyCode.Space) && IsGround())) return;

        rb.linearVelocityY = jumpPower;

        // rb.linearVelocityY = Input.GetKeyDown(KeyCode.Space) && IsGround()
        //     ? jumpPower : rb.linearVelocityY;
    }

    void Move()
    {
        rb.linearVelocityX = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    void Update()
    {
        Move();
        Jump();
    }
}
