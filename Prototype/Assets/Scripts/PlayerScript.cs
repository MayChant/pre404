using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public Animator anim;

    void moveTo(Vector3 newPos)
    {
        // TODO: write collision with all objects
    }

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos;
        if (Input.GetKeyDown("left"))
        {
            anim.SetTrigger("PressLeft");
            newPos = new Vector3(transform.position.x-0.64f, transform.position.y, transform.position.z);
            moveTo(newPos);

            //transform.Translate(new Vector3(-0.64f, 0f, 0f));
        }
        else if (Input.GetKeyDown("up"))
        {
            anim.SetTrigger("PressUp");
            //transform.Translate(new Vector3(0f, 0.64f, 0f));
            newPos = new Vector3(transform.position.x, transform.position.y+0.64f, transform.position.z);
            moveTo(newPos);
        }
        else if (Input.GetKeyDown("right"))
        {
            anim.SetTrigger("PressRight");
            //transform.Translate(new Vector3(0.64f, 0f, 0f));
            newPos = new Vector3(transform.position.x + 0.64f, transform.position.y, transform.position.z);
            moveTo(newPos);
        }
        else if (Input.GetKeyDown("down"))
        {
            anim.SetTrigger("PressDown");
            //transform.Translate(new Vector3(0f, -0.64f, 0f));
            newPos = new Vector3(transform.position.x, transform.position.y - 0.64f, transform.position.z);
            moveTo(newPos);
        }
        
    }
}
