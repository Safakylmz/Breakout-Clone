using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed; //topun hýzý    
    private int randomXForce; //topun ilk güç uygulanýrken saða veya sola gitmesini saðlamak. düz gitmemesini saðlamak için.
    private Vector2 upForce;
    private bool isBallMoving;

    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        StartingForce();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("GameOver"))
        {
            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            isBallMoving = false;
        }
    }
    private void StartingForce()
    {
        randomXForce = Random.value > .5f ? 1 : -1; //top ya 1 deðeri ile sola ya da -1 deðeri ile saða gidecek. 0 deðeri yok düz gitmek yok.
        upForce = new Vector2(randomXForce, 1); // topun deðerleri 

        if (Input.GetKeyDown(KeyCode.Mouse0) && !isBallMoving)
        {
            isBallMoving = true;
            rb.AddForce(upForce * speed);
        }

    }
}
