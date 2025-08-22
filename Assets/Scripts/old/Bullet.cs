using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float bullet_speed;
    public float bullet_lifetime = 3f;
    void Start()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 dir = mousePos - transform.position;


        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle * -1);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(dir * bullet_speed, ForceMode2D.Impulse);
        Invoke("DestroyBullet", bullet_lifetime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
