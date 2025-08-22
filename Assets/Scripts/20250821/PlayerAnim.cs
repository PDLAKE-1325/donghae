using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    // public : 스크립트 외부, 내부 모두 접근가능, 인스펙터 창에서 보임
    // private : 스크립트 내부에서만 접근가능, 인스펙터 창에서 안보임
    // [SerializeField] : 스크립트 내부에서만 접근 가능, 인스펙터 창에서 보임
    // public float jump_power { get; private set; } : 얘는 스크립트 외부에서 참고 가능하나 수정불가

    [SerializeField] float move_speed;
    [SerializeField] float jump_power;
    [SerializeField] float ground_detect_length;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Animator animator;

    void Move()
    {
        rb.linearVelocityX = Input.GetAxisRaw("Horizontal") * move_speed;
        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
        {
            animator.SetTrigger("jump_");
            rb.linearVelocityY = jump_power;
        }
    }
    bool OnGround()
    {
        bool result;
        RaycastHit2D hit = Physics2D.Linecast(transform.position,
            transform.position + Vector3.down * ground_detect_length, groundLayer);
        result = hit.collider != null;
        return result;
    }
    #region  이제시작 ㅋ 30분 안에 못나감

    [SerializeField] SpriteRenderer spriteRenderer;
    void 황동화()
    {
        animator.SetBool("move", rb.linearVelocityX != 0);
        animator.SetBool("jump", rb.linearVelocityY != 0);
        spriteRenderer.flipX = rb.linearVelocityX > 0;
    }

    #endregion
    void Update()
    {
        Move();
        황동화();
    }
}
