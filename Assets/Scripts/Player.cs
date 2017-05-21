using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 4;
	public bool shift = false;
	public int numOfDirections = 0;
	public float bounds = 3;

	public Vector2 direction_vector;

	enum dir { UP, DOWN, LEFT, RIGHT };

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		numOfDirections = 0;

		// movement logic
		if (Input.GetKeyDown("left shift")) {
			shift = true;
		}

		//checks directions
		if (Input.GetKey("up")) { numOfDirections++; }
		else if (Input.GetKey("down")) { numOfDirections++; }
		if (Input.GetKey("left")) { numOfDirections++; }
		else if (Input.GetKey("right")) { numOfDirections++; }

		//moves
		if (Input.GetKey("up")) { move(dir.UP); }
		else if (Input.GetKey("down")) { move(dir.DOWN); }
		if (Input.GetKey("left")) { move(dir.LEFT); }
		else if (Input.GetKey("right")) { move(dir.RIGHT); }

	}

	void checkAlive() {

		if (Input.GetKey("up")) move(dir.UP);
		else if (Input.GetKey("down")) move(dir.DOWN);
		if (Input.GetKey("left")) move(dir.LEFT);
		else if (Input.GetKey("right")) move(dir.RIGHT);

	}

	void checkBounds(){
		//checking if outside bounds

		Debug.Log(transform.position.x + ", " + transform.position.y);

		if(transform.position.x >= 3.0) {

			transform.position = new Vector2(3.0f, transform.position.y);

			Debug.Log("edge");
		}
		else if(transform.position.x <= -3.0) {

			transform.position = new Vector2(-3.0f, transform.position.y);

			Debug.Log("edge");
		}
		if(transform.position.y >= 3.0) {

			transform.position = new Vector2(transform.position.x, 3.0f);

			Debug.Log("edge");
		}
		else if(transform.position.y <= -3.0) {

			transform.position = new Vector2(transform.position.x, -3.0f);

			Debug.Log("edge");
		}
	}

	void move(dir direction) {

		if(shift) speed = 2;
		else speed = 4;
		if(numOfDirections==2) speed *= 0.6f;

		//moving

		if(direction == dir.UP) {
			direction_vector = new Vector2(0, 1);
			transform.Translate(direction_vector*speed*Time.deltaTime);
		}
		else if(direction == dir.DOWN) {
			direction_vector = new Vector2(0, -1);
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

		checkBounds();


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
