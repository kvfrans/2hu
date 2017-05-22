using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	// Use this for initialization

	void Start () {
		StartCoroutine(delete());
	}

	IEnumerator delete()
	{
		yield return new WaitForSeconds(0.1f);
		Destroy(gameObject);
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
        		b.HitBomb();
        		// do stuff that happens when you're hit
        	}
        }

    }
}
