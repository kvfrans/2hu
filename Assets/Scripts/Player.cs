using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Vector2 speed;
	public int x, y;
	public float direction;
	public bool shift;

	enum dir { UP, DOWN, LEFT, RIGHT };

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		//sets shift to false, and then checks if the shift is pressed
		shift = false;
		if ((Control.ModifierKeys & Keys.Shift) != 0) shift = true;

		//checks move direction
		if ((Control.ModifierKeys & Keys.Up) != 0) move(dir.UP);
		else if ((Control.ModifierKeys & Keys.Down) != 0) move(dir.DOWN);
		else if ((Control.ModifierKeys & Keys.Left) != 0) move(dir.LEFT);
		else if ((Control.ModifierKeys & Keys.Right) != 0) move(dir.RIGHT);


		move();

	}

	void checkAlive() {

	}

	void move(dir direction) {

		if(shift) {
			speed = 4;
		}
		else speed = 2;

		if(direction = dir.UP) {
			x += speed;
		}
		else if(direction = dir.DOWN) {
			x -= speed;
		}
		else if(direction = dir.LEFT) {
			y -= speed;
		}
		else if(direction = dir.RIGHT) {
			x += speed;
		}

	}
 
}
