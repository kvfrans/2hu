using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// movement + shooting
	float speed = 4;
	bool shift = false;
	bool fire = false;
	int numOfDirections = 0;
	float bounds = 3;
	float timer = 0.0f;
	float fireSpeedIncrement = 0.02f;

	float invincibleTimer = 0.0f;

	Vector2 direction_vector;

	// Prefab references
	public Transform playerbullet;
	public Transform bomb;

	enum dir { UP, DOWN, LEFT, RIGHT };

	public float score = 0;
	public float graze = 0;
	public float lives = 3;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		numOfDirections = 0;

		// movement logic
		if (Input.GetKeyDown(Helper.Instance.keybinds["shift"])) {
			shift = true;
		}
		if (Input.GetKeyUp(Helper.Instance.keybinds["shift"])) {
			shift = false;
		}

		//checks directions

		if (Input.GetKeyDown(Helper.Instance.keybinds["shoot"])) { fire = true; }
		if (Input.GetKeyUp(Helper.Instance.keybinds["shoot"])) { fire = false; }
		if (fire) shoot();

		if(Input.GetKeyDown(Helper.Instance.keybinds["bomb"])) { makeBomb(); }

		if (Input.GetKey(Helper.Instance.keybinds["up"])) { numOfDirections++; }
		else if (Input.GetKey(Helper.Instance.keybinds["down"])) { numOfDirections++; }
		if (Input.GetKey(Helper.Instance.keybinds["left"])) { numOfDirections++; }
		else if (Input.GetKey(Helper.Instance.keybinds["right"])) { numOfDirections++; }

		//moves
		if (Input.GetKey(Helper.Instance.keybinds["up"])) { move(dir.UP); }
		else if (Input.GetKey(Helper.Instance.keybinds["down"])) { move(dir.DOWN); }
		if (Input.GetKey(Helper.Instance.keybinds["left"])) { move(dir.LEFT); }
		else if (Input.GetKey(Helper.Instance.keybinds["right"])) { move(dir.RIGHT); }

		if(invincibleTimer > 0.0f)
		{
			invincibleTimer -= Helper.Instance.gameplayDeltaTime();
		}

	}

	void checkAlive() {

		if (Input.GetKey(Helper.Instance.keybinds["up"])) move(dir.UP);
		else if (Input.GetKey(Helper.Instance.keybinds["down"])) move(dir.DOWN);
		if (Input.GetKey(Helper.Instance.keybinds["left"])) move(dir.LEFT);
		else if (Input.GetKey(Helper.Instance.keybinds["right"])) move(dir.RIGHT);

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

		timer += Helper.Instance.gameplayDeltaTime();

		if(timer > 0.2f) {
			timer = 0;

			Transform b = Instantiate(playerbullet);
			Transform b2 = Instantiate(playerbullet);

			b.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
			b2.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
		}
	}

	void makeBomb(){

		Transform b = Instantiate(bomb);
		b.position = transform.position;
	}

	void onHit(){
		//clears bullets and respawns
		if(invincibleTimer <= 0.0f)
		{
			makeBomb();
			graze--;
			lives--;
			transform.position = new Vector2(-2,-3);
			invincibleTimer = 1.0f;
		}
	}

	void move(dir direction) {

		if(shift) speed = 2;
		else speed = 4;
		if(numOfDirections==2) speed *= 0.6f;

		//moving

		if(direction == dir.UP) {
			direction_vector = new Vector2(0, 1);
			transform.Translate(direction_vector*speed*Helper.Instance.gameplayDeltaTime()*Helper.Instance.gameSpeed);
		}
		else if(direction == dir.DOWN) {
			direction_vector = new Vector2(0, -1);
			transform.Translate(direction_vector*speed*Helper.Instance.gameplayDeltaTime()*Helper.Instance.gameSpeed);
		}
		if(direction == dir.LEFT) {
			direction_vector = new Vector2(-1, 0);
			transform.Translate(direction_vector*speed*Helper.Instance.gameplayDeltaTime()*Helper.Instance.gameSpeed);
		}
		else if(direction == dir.RIGHT) {
			direction_vector = new Vector2(1, 0);
			transform.Translate(direction_vector*speed*Helper.Instance.gameplayDeltaTime()*Helper.Instance.gameSpeed);
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
				onHit();
        	}
        }

    }

}
