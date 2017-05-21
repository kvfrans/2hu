using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graze : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
        Bullet b = other.gameObject.GetComponent<Bullet>();
        if(b != null)
        {
        	if(b.type == Bullet.bullet_type.ENEMY && !b.grazed)
        	{
				player.GetComponent<Player>().graze++;
				b.grazedPlayer();
        		// do stuff that happens when you're hit like update graze count

        	}
        }
    }

}
