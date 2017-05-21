using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	Transform player; // player postion
	public int startingHealth = 100;
	public int currentHealth;
	bool isDead;


	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").transform;
		currentHealth = startingHealth;

	}

	// Update is called once per frame
	void Update () {
		//prob shoot some bullets at the player

	}

	public void TakeDamage (int amount, Vector3 hitPoint) {
		//do some animation in regards to where boss is hit

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
}
