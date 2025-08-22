using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform startPos;
    public Vector3 startPos2;

    public int hp = 100;

    public bool cooldown;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Invoke("DestroyThis", 1);
        // InvokeRepeating("HpDown", 1, 2);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !cooldown)
        {
            cooldown = true;
            Invoke("Cool", 3);
            print("hi");
        }
    }
    void Cool()
    {
        cooldown = false;
    }


    void HpDown()
    {
        print(--hp);
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }
}
