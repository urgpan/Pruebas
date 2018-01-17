using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Movimiento y salto
    public float speed;
    public float jumpPower;

    //Espacio pulsado
    bool jumpRequest;

    //OnGround
    public Transform piesPosition;
    public LayerMask whatsGround;
    bool onGround;

    //Inercia en el salto
    float directionInertia;
    public float inertiaPower;

    //Componentes
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
        onGround = Physics2D.OverlapCircle(piesPosition.position, 0.05f, whatsGround);
        

        Movimiento();

        if (jumpRequest && onGround)//Si se cumplen los requisitos para saltar: saltar        
        {
            Salto();
            directionInertia = Input.GetAxis("Horizontal");
        }

        if (!onGround && Input.GetButton("Jump"))
                Incercia();


    }
    void Movimiento ()
    {
        //Movimiento
        rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);

      
    }
    void Salto()
    {
       //Impulso hacia arriba
        rb.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);

        jumpRequest = false;
    }
    void Incercia()
    {       //Cuando jump esta pulsado, ejercer una fuerza en la direccion del salto en la horizontal
            rb.AddForce(Vector2.right * directionInertia * inertiaPower);
    }
}
