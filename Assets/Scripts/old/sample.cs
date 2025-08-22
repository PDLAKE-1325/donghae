// //player.cs

// using UnityEngine;

// public class player : MonoBehaviour
// {

//     public float move_speed = 1.0f;
//     void Update()
//     {
//         float x = Input.GetAxisRaw("Horizontal");
//         float y = Input.GetAxisRaw("Vertical");

//         Vector3 moveVector = new(x, y);
//         moveVector = moveVector.normalized * move_speed;

//         transform.position += moveVector * Time.deltaTime;

//     }
// }

// //zisun.cs

// public class zisun : MonoBehaviour
// {

//     public Transform transF;

//     void Update()
//     {
//         float x = transF.position.x - transform.position.x;
//         float y = transF.position.y - transform.position.y;

//         Vector3 moveVector = new(x, y);
//         moveVector = moveVector.normalized;

//         transform.position += moveVector * Time.deltaTime;
//     }
// }