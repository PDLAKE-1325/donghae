using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet_prefab;
    public Transform shoot_point;

    public float shoot_cool;
    public int max_ammo;
    public float reloading_cool;

    [Range(0.1f, 8)]
    public float move_speed;

    int cur_ammo;
    bool on_delay;
    bool on_realod;

    #region Private Methods
    void Shoot()
    {
        if (!Input.GetMouseButton(0) || on_delay || on_realod || cur_ammo <= 0) return;
        on_delay = true;
        print($"shoot ( {--cur_ammo} / {max_ammo} )");
        StartCoroutine(ShootCool());
        GameObject obj = Instantiate(bullet_prefab);
        obj.transform.position = transform.position;
    }

    IEnumerator Reload()
    {
        if (cur_ammo == max_ammo) yield break;
        on_realod = true;
        yield return new WaitForSeconds(reloading_cool);
        cur_ammo = max_ammo;
        on_realod = false;
    }

    IEnumerator ShootCool()
    {
        yield return new WaitForSeconds(shoot_cool);
        on_delay = false;
    }

    void Gun()
    {
        Shoot();
        if (Input.GetKeyDown(KeyCode.R)) StartCoroutine(Reload());
    }

    void Move()
    {
        Vector2 moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVector *= move_speed;
        transform.position += (Vector3)moveVector * Time.deltaTime;
    }
    #endregion

    #region Public Methods
    #endregion

    #region Unity Methods
    void Start()
    {
        cur_ammo = max_ammo;
    }

    void Update()
    {
        Gun();
        Move();
    }
    #endregion
}
