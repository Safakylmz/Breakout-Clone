using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public float speed; //topun hýzý    
    private int randomXForce; //topun ilk güç uygulanýrken saða veya sola gitmesini saðlamak. düz gitmemesini saðlamak için.
    private Vector2 upForce;
    private bool isBallMoving;

    private Rigidbody2D rb;

    private int score = 0;
    private int lives = 3;
    private int brickCount; //oyunu kazanma ekraný için


    public TextMeshProUGUI scoreText;
    public GameObject[] livesImage;
    public GameObject gameOverPanel;
    public GameObject youWinPanel;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brickCount = FindObjectOfType<LevelGenerator>().transform.childCount; // tuðla sayýsýný alýyor oyun baþýnda.
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
            score += 10;
            scoreText.text = "Score " + score.ToString("0000");
            brickCount--;
            if(brickCount <= 0)
            {
                youWinPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (collision.gameObject.CompareTag("GameOver"))
        {
            lives--;
            livesImage[lives].SetActive(false);
            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            isBallMoving = false;

            if (lives <= 0)
            {
                gameOverPanel.SetActive(true);
                Time.timeScale = 0;
                Destroy(gameObject);
            }
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
