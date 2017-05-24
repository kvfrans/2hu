using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cirno : MonoBehaviour {

	// private vars
	float timer = 0;
	enum phases { perfect_freeze_1, perfect_freeze_2, perfect_freeze_3 };
	phases phase = phases.perfect_freeze_1;
	// phase 1 stuff
	float rotation = 0;
	float rateofchange = 0;

	// prefab references
	public Transform cirnobullet;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		timer += Helper.Instance.gameplayDeltaTime();
		switch (phase) {
			case phases.perfect_freeze_1:
				if(timer > 0.6)
				{
					for(int i = 0; i < 8; i++)
					{
						Transform b = Instantiate(cirnobullet);
						Bullet bs = b.GetComponent<Bullet>();
						b.position = transform.position;
						bs.setDirection(Random.value * 360.0f);
					}
				}
				break;
			case phases.perfect_freeze_2:
				if(timer > 0.2)
				{
					timer = 0;
					for(int i = 0; i < 8; i++)
					{
						Transform b = Instantiate(cirnobullet);
						Bullet bs = b.GetComponent<Bullet>();
						b.position = transform.position;
						bs.setDirection(Random.value * 360.0f);
					}
				}
				break;
			case phases.perfect_freeze_3:
				break;
		}
	}

	void BossDead()
	{
		phase = phases.perfect_freeze_2;
		transform.position = new Vector2(-2, 0);
	}
}
