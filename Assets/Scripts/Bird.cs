using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float upforce = 200f;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(isDead == false) {
            if(Input.GetMouseButtonDown(0)) {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upforce));
                anim.SetTrigger("Flap");
            }
        }

	}

    void OnCollisionEnter2D(Collision2D other) {
        // Zero out the bird's velocity
        rb2d.velocity = Vector2.zero;
        // If the bird collides with something set it to dead...
        isDead = true;
        //...tell the Animator about it...
        anim.SetTrigger ("Die");
        GameControl.instance.BirdDied();
    }
}
