using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed; //topun h�z�    
    private int randomXForce; //topun ilk g�� uygulan�rken sa�a veya sola gitmesini sa�lamak. d�z gitmemesini sa�lamak i�in.
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
        randomXForce = Random.value > .5f ? 1 : -1; //top ya 1 de�eri ile sola ya da -1 de�eri ile sa�a gidecek. 0 de�eri yok d�z gitmek yok.
        upForce = new Vector2(randomXForce, 1); // topun de�erleri 

        if (Input.GetKeyDown(KeyCode.Mouse0) && !isBallMoving)
        {
            isBallMoving = true;
            rb.AddForce(upForce * speed);
        }

    }
}
