using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelElement : MonoBehaviour {

    public bool isPassable; /* Can coexist with other elements in the same position*/
    public bool isPickedUp; /* Destroyed when player gets to the same position */
    public bool isUnique; /* Cannot exist multiple of the element in the same level */
    public bool isMandatory; /* This element must be present in a level */
    public bool isDestroyed; /* This element is flagged as destroyed */
    public int x_pos, y_pos; /* Current position of the element */

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
