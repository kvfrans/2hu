﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour {

	// Prefab references
	public Transform player;

	public Transform boss1;
	public Transform boss2;

	// Use this for initialization
	void Start () {
		Transform p = Instantiate(player);
		p.position = new Vector2(0,0);

		Transform b = Instantiate(boss1);
		b.position = new Vector2(0,3);
		b.GetComponent<Boss>().player = p;
	}

	// Update is called once per frame
	void Update () {

	}
}
