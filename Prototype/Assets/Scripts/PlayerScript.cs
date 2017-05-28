using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MovingObject
{

    public Animator anim;

    void moveTo(float xDir, float yDir)
    {
        // TODO: write collision with all objects

        RaycastHit2D hit;
        Move(xDir, yDir, out hit);

    }

	// Use this for initialization
	void Awake () {
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("left"))
        {
            anim.SetTrigger("PressLeft");
            //newPos = new Vector3(transform.position.x-0.64f, transform.position.y, transform.position.z);
            moveTo(-0.64f, 0f);

            //transform.Translate(new Vector3(-0.64f, 0f, 0f));
        }
        else if (Input.GetKeyDown("up"))
        {
            anim.SetTrigger("PressUp");
            //transform.Translate(new Vector3(0f, 0.64f, 0f));
            //newPos = new Vector3(transform.position.x, transform.position.y+0.64f, transform.position.z);
            moveTo(0f, 0.64f);
        }
        else if (Input.GetKeyDown("right"))
        {
            anim.SetTrigger("PressRight");
            //transform.Translate(new Vector3(0.64f, 0f, 0f));
            //newPos = new Vector3(transform.position.x + 0.64f, transform.position.y, transform.position.z);
            moveTo(0.64f, 0f);
        }
        else if (Input.GetKeyDown("down"))
        {
            anim.SetTrigger("PressDown");
            //transform.Translate(new Vector3(0f, -0.64f, 0f));
            //newPos = new Vector3(transform.position.x, transform.position.y - 0.64f, transform.position.z);
            moveTo(0f, -0.64f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //TODO: put your trigger code for other game elements here
        //e.g.
        /*
         * if (other.tag=='blah') {
         *   other.gameObject.SetActive(false);//This destroys the object
         *}
        */
    }
}
