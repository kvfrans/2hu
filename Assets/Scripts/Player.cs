using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 4;
	public bool shift = false;
	public bool fire = false;
	public int numOfDirections = 0;
	public float bounds = 3;
	public float timer = 0.0f;
	public float fireSpeedIncrement = 0.02f;

	public Vector2 direction_vector;

	public Transform playerbullet;

	enum dir { UP, DOWN, LEFT, RIGHT };

	public float score = 0;
	public float graze = 0;


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

		if (Input.GetKeyDown("z")) { fire = true; }
		if (Input.GetKeyUp("z")) { fire = false; }

		if (fire) shoot();

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

		// Debug.Log(transform.position.x + ", " + transform.position.y);

		if(transform.position.x >= 1.94) {

			transform.position = new Vector2(1.94f, transform.position.y);

			// Debug.Log("edge");
		}
		else if(transform.position.x <= -6.2) {

			transform.position = new Vector2(-6.2f, transform.position.y);

			// Debug.Log("edge");
		}
		if(transform.position.y >= 4.44) {

			transform.position = new Vector2(transform.position.x, 4.44f);

			// Debug.Log("edge");
		}
		else if(transform.position.y <= -4.4) {

			transform.position = new Vector2(transform.position.x, -4.4f);

			// Debug.Log("edge");
		}
	}

	void shoot(){

		timer += Time.deltaTime;

		if(timer > 0.2f) {
			timer = 0;

			Transform b = Instantiate(playerbullet);
			Transform b2 = Instantiate(playerbullet);

			b.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
			b2.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
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
				graze--;
        		// do stuff that happens when you're hit
        	}
        }
    }

}
