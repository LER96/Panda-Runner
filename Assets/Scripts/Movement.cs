using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Movement : MonoBehaviour
{
    public Text scoreText;
    public Text DistanceText;
    public GameObject End;
    public Text highScoreText;

    public int score = 0;
    public float speed = 5;
    public float accelerate=2, maxaccelerate=10;
    public float distance;

    [SerializeField] Rigidbody rb;
    float horizontalInput;
    [SerializeField] float horizontalMulti = 1.5f;
    public bool alive = true;
    Vector3 forwardMovement;
    float right, left;


    public float secondAcce=4;
    public float Destroysec = 5;
    private void FixedUpdate()
    {
        //pause the game
        if (!alive)
        {
            return;
        }

        //player movment
        forwardMovement = transform.forward * speed*Time.fixedDeltaTime;
        Vector3 horizontalMovement = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMulti;
        rb.MovePosition(rb.position + forwardMovement + horizontalMovement);

        //distance calculate
        distance = (int)transform.position.z;

    }

    // Start is called before the first frame update
    void Start()
    {
        left = -9;
        right = 9;
        score = 0;

        //highScoreText.text = $"HighScore: {PlayerPrefs.GetFloat("HighScore")}";
    }

    // Update is called once per frame
    void Update()
    {
        //States Text
        scoreText.text = "Bamboo: " + score;
        DistanceText.text = "Distance: " +distance+"m";

        //Movment input
        horizontalInput = Input.GetAxis("Horizontal");

        //movment bounds 
        if (transform.position.x < left)
        {
            transform.position = new Vector3(left + 0.5f, transform.position.y, transform.position.z);     
        }
        if (transform.position.x > right)
        {
            transform.position = new Vector3(right - 0.5f, transform.position.y, transform.position.z);
        }

        //Acceleration per time 
        if (secondAcce > 0)
        {
            secondAcce -= Time.deltaTime;
        }
        else
        {
            secondAcce = 2;
            float velocityRatio = speed / maxaccelerate;
            accelerate = maxaccelerate * (1 - velocityRatio);
            speed += accelerate * Time.deltaTime;
            if (speed >= maxaccelerate)
            {
                speed = maxaccelerate;
            }
        }
    }

    public void Death()
    {
        //make a game manager script and add it there later
        End.SetActive(true);
        alive = false;
        //Invoke("Restart", 0.5f);
        Time.timeScale = 0;
        if (distance > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", distance);
        }
        highScoreText.text = $"HighScore: {PlayerPrefs.GetFloat("HighScore")}";
    }

    private void Restart()
    {
        //reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Death();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name);
        //destory the lvl section
        Destroy(other.transform.root.gameObject, Destroysec);
    }

    private void OnTriggerEnter(Collider other)
    {
        //collect coin
        if(other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            score++;
        }
    }
}
