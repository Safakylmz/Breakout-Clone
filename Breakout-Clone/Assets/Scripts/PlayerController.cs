using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horizontalLimit;

    private float input;
    private Vector2 position;

    private void Update()
    {
        HorizontalMovement();
    }

    private void HorizontalMovement()
    {
        input = Input.GetAxis("Horizontal"); //input deðeri -1 ile 1 arasýna sabitleniyor
        position = transform.position; // position deðeri gameobjenin þu anki deðerine sabit.

        position.x += input * speed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -horizontalLimit, horizontalLimit);  //scene dýþýna çýkmasýn diye limit.

        transform.position = position;
    }
}
