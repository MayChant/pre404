using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyScript : MovingObject {
	private string cur_dir;
	bool moveTo(float xDir, float yDir)
	{
		// TODO: write collision with all objects

		RaycastHit2D hit;
		return Move(xDir*Time.deltaTime, yDir, out hit);

	}

	// Use this for initialization
	void Awake () {
	}

	// Update is called once per frame
	void Update () {
		if (cur_dir == null) {
			cur_dir = "left";
		}
		else if (cur_dir == "left") {
			if (moveTo (-0.64f, 0f) == false) {
				cur_dir = "right";
			}
		}
		else if (cur_dir == "right") {
			if (moveTo (0.64f, 0f) == false) {
				cur_dir = "left";
			}
		}
	}
}
