using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public enum dir { UP, DOWN, LEFT, RIGHT };

	public float speed = 4;
	public bool shift;

	public Vector2 direction_vector;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// //sets shift to false, and then checks if the shift is pressed
		shift = false;


		Debug.Log(Input.GetKey("right"));
		// //checks move direction
		// if ((Control.ModifierKeys & Keys.Up) != 0) move(dir.UP);
		// else if ((Control.ModifierKeys & Keys.Down) != 0) move(dir.DOWN);
		// else if ((Control.ModifierKeys & Keys.Left) != 0) move(dir.LEFT);
		// else if ((Control.ModifierKeys & Keys.Right) != 0) move(dir.RIGHT);

		if (Input.GetKeyDown("shift")) {
			if(shift) speed = 2;
		}
		if (Input.GetKey("up")) {
			Debug.Log("same");
			move(dir.UP);
		}
		else if (Input.GetKey("down")) move(dir.DOWN);
		if (Input.GetKey("left")) move(dir.LEFT);
		else if (Input.GetKey("right")) move(dir.RIGHT);


		// move();

	}

	void checkAlive() {

	}

	void move(dir direction) {

		if(direction == dir.UP) {
			direction_vector = new Vector2(0, -1);
			transform.Translate(direction_vector*speed*Time.deltaTime);
		}
		else if(direction == dir.DOWN) {
			direction_vector = new Vector2(0, 1);
			transform.Translate(direction_vector*speed*Time.deltaTime);
		}
		if(direction == dir.LEFT) {			
			direction_vector = new Vector2(-1, 0);
			transform.Translate(direction_vector*speed*Time.deltaTime);
		}
		else if(direction == dir.RIGHT) {
			direction_vector = new Vector2(1, 0);
			transform.Translate(direction_vector*speed*Time.deltaTime);
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
        Bullet b = other.gameObject.GetComponent<Bullet>();
        if(b != null)
        {
        	if(b.type == Bullet.bullet_type.ENEMY)
        	{
        		b.HitPlayer();
        		// do stuff that happens when you're hit
        	}
        }
    }

}
