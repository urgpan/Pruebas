using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {

    public float multiplicadorCaida = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
    void FixedUpdate()
    {
        if (rb.velocity.y < 0)
            rb.gravityScale = multiplicadorCaida;
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            rb.gravityScale = lowJumpMultiplier;
        else
        {
            rb.gravityScale = 1f;
        }


    }
	

}
