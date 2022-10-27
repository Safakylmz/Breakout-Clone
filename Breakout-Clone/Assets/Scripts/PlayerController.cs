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
        input = Input.GetAxis("Horizontal"); //input de�eri -1 ile 1 aras�na sabitleniyor
        position = transform.position; // position de�eri gameobjenin �u anki de�erine sabit.

        position.x += input * speed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -horizontalLimit, horizontalLimit);  //scene d���na ��kmas�n diye limit.

        transform.position = position;
    }
}
