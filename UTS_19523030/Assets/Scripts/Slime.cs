using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour{
    Rigidbody2D rb;
	Animator anim;
	float moveSpeed = 10f;
	bool facingRight = true;
	Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate(){
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveSpeed*move, rb.velocity.y);
        
        if(moveSpeed*move == 0.0){
            anim.SetBool ("isWalking", false);
            anim.SetBool ("isIdle", true);
        }else{
            anim.SetBool ("isWalking", true);
            anim.SetBool ("isIdle", false);
        }

        if (moveSpeed*move > 0)
			facingRight = true;
		else if (moveSpeed*move < 0)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;
        
    }
}
