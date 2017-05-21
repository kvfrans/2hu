using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public enum dir { UP, DOWN, LEFT, RIGHT };

	public float speed = 4;
	public bool shift = false;
	public int numOfDirections = 0;

	public Vector2 direction_vector;


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
		if (Input.GetKey("up")) {
			numOfDirections++;
			move(dir.UP);
		}
		else if (Input.GetKey("down")) {
			numOfDirections++;
			move(dir.DOWN);
		}
		if (Input.GetKey("left")) {
			numOfDirections++;
			move(dir.LEFT);
		}
		else if (Input.GetKey("right")) {
			numOfDirections++;
			move(dir.RIGHT);
		}

	}

	void checkAlive() {

	}

	void canMove(){
		//checking if outside bounds
		if(transform.position.x >= 500) {

			transform.position = new Vector2(500, transform.position.y);

			Debug.Log("edge");
			return;
		}
		else if(transform.position.x <= 0) {

			transform.position = new Vector2(0, transform.position.y);

			Debug.Log("edge");
			return;
		}
		if(transform.position.x >= 500) {

			transform.position = new Vector2(transform.position.x, 500);

			Debug.Log("edge");
			return;
		}
		else if(transform.position.x <= 0) {

			transform.position = new Vector2(transform.position.x, 0);

			Debug.Log("edge");
			return;
		}
	}

	void move(dir direction) {

		if(shift) speed = 2;
		else speed = 4;
		if(numOfDirections==2) speed * Math.Sqrt(2);


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

		if(Input.GetKeyUp("left shift")) shift = false;
		Debug.Log(shift);

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
