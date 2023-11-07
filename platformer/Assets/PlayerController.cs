using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Movement Variable 
    Rigidbody2D rb; //create reference for rigidbody bc jump requires physics
    public float jumpForce; //the force that will be added to the vertical component of player's velocity
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        Vector3 newScale = transform.localScale;
        float currentScale = Mathf.Abs(transform.localScale.x);

        //player moves left
        if (Input.GetKey("a"))
        { 
            newPosition.x -= speed;
            newScale.x = currentScale;
        }

        //player moves right
        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
            newScale.y = currentScale;
        }

        if (Input.GetKeyDown("w"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        transform.position = newPosition;
        transform.localScale = newScale;
          
    }
}
