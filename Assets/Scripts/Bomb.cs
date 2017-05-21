using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	private int x, y;


	// Use this for initialization

	void Start (Player player) {
		player.getX();
		player.getY();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
