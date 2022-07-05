using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField]
    private float speed = 5f;
    public float forForce = 100f;
    private float moveX;
    public Vector3 respawnPoint;
    public GameManager gameManager;
    public GameObject gameObjectWin1;

    private void Awake()
    {
        respawnPoint = this.transform.position;
    }




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        InputManager();
    }



    void FixedUpdate()
    {
        rb.AddForce(0, 0, forForce * Time.fixedDeltaTime);

        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, rb.velocity.z);

        FallDet();
    }


    private void InputManager()
    {
        moveX = Input.GetAxis("Horizontal");


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Box"))
        {
            gameManager.RespawnPlayer();


        }

        if (collision.collider.CompareTag("Finish"))
        {
            gameObjectWin1.SetActive(true);
            Destroy(gameObject);
        }


    }

    private void FallDet()
    {
        if(rb.position.y < -1f)
        {
            SceneManager.LoadScene(4);
        }

    }

}

