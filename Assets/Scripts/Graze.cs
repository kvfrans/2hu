using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graze : MonoBehaviour {

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
        	if(b.type == Bullet.bullet_type.ENEMY)
        	{
				Debug.Log("assme");
        		// do stuff that happens when you're hit
        	}
        }
    }

}
