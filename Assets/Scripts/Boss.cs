using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	// real references
	public Transform player; // player postion

	//Script References
	Player p;

	// boss variables
	public int startingHealth = 100;
	public int currentHealth;
	bool isDead;


	// Use this for initialization
	void Start () {
		p = player.GetComponent<Player>();
		// player.position
		currentHealth = startingHealth;

	}

	// Update is called once per frame
	void Update () {
		//prob shoot some bullets at the player

	}
	public void TakeDamage (int amount) {
	// public void TakeDamage (int amount, Vector2 hitPoint) {
		//do some animation in regards to where boss is hit maybe

		if(isDead)
		   // ... no need to take damage so exit the function.
		   return;

		currentHealth -= amount;

		if(currentHealth <= 0)
        {
            Death();
        }
	}

	void Death ()
    {
		// can trigger some cutscenes here, animations, etc
        isDead = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		Bullet b = other.gameObject.GetComponent<Bullet>();
		if(b != null)
		{
			if(b.type == Bullet.bullet_type.PLAYER && !isDead)
			{
				b.HitEnemy();
				TakeDamage(2);
			}
		}
	}
}
