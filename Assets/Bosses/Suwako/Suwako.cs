using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suwako : MonoBehaviour {

	// private vars
	float timer = 0;
	int phase = 0;

	// prefab references
	public Transform suwabullet;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(phase == 0)
		{
			if(timer > 2)
			{
				timer = 0;
				Transform b = Instantiate(suwabullet);
				b.position = transform.position;
			}
		}
	}
}
