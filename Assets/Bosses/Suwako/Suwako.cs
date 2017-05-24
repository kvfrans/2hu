using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suwako : MonoBehaviour {

	// private vars
	float timer = 0;
	enum phases { uno, dos, tres };
	phases phase = phases.uno;
	// phase 1 stuff
	float rotation = 0;
	float rateofchange = 0;

	// prefab references
	public Transform suwabullet;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		switch (phase) {
			case phases.uno:
				if(timer > 0.6)
				{
					rotation += rateofchange;
					rateofchange += Random.value * 2 - 1;
					timer = 0;
					for(int i = 0; i < 36; i++)
					{
						Transform b = Instantiate(suwabullet);
						Bullet bs = b.GetComponent<Bullet>();
						b.position = transform.position;
						bs.setDirection(i*10 + rotation);
					}
				}
				break;
			case phases.dos:
				if(timer > 0.2)
				{
					timer = 0;
					for(int i = 0; i < 8; i++)
					{
						Transform b = Instantiate(suwabullet);
						Bullet bs = b.GetComponent<Bullet>();
						b.position = transform.position;
						bs.setDirection(Random.value * 360.0f);
					}
				}
				break;
			case phases.tres:
				break;
		}
	}

	void BossDead()
	{
		phase = phases.dos;
		transform.position = new Vector2(-2, 0);
	}
}
