using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	// Use this for initialization
	float timer = 0.0f;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		timer += Helper.Instance.gameplayDeltaTime();
		transform.localScale = new Vector2(timer*50, timer*50);
		if(timer > 0.4)
		{
			Destroy(gameObject);
		}
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
