using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //importing SceneManagement Library

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    Rigidbody2D rb; //create reference for rigidbody bc jump requires physics
    public float jumpForce; //the force that will be added to the vertical component of player's velocity
    public float speed = 0.2f;

    //Ground Check Variables
    public LayerMask groundLayer;//layer information
    public Transform groundCheck;// player position info
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .5f, groundLayer);

        Vector3 newPosition = transform.position;
        Vector3 newScale = transform.localScale;
        float currentScale = Mathf.Abs(transform.localScale.x);

        //player moves left
        if (Input.GetKey("a"))
        {
            newPosition.x -= speed;
            newScale.x = -currentScale;
        }

        //player moves right
        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
            newScale.x = currentScale;
        }


        if (Input.GetKeyDown("w") && isGrounded == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        transform.position = newPosition;
        transform.localScale = newScale;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("END"))
        {
            Debug.Log("hit");
            SceneManager.LoadScene(2); //access SceneManager class for LoadScene function
        }
    }
}