using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float maxSpeed;
    public float jumpSpeed;
    bool jumpRequest;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            jumpRequest = true;
    }
    private void FixedUpdate()
    {
        Movimiento();

        if(jumpRequest)        
             Salto();
    }
    void Movimiento ()
    {

        rb.velocity = new Vector2( speed * Input.GetAxis("Horizontal"),rb.velocity.y);

    }
    void Salto()
    {       
        rb.AddForce(Vector2.up * jumpSpeed,ForceMode2D.Impulse);
        jumpRequest = false;

    }
}
