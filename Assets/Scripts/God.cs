using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour {

	// Prefab references
	public Transform player;
	public Transform boss1;
	public Transform boss2;

	//GUI references
	public Transform score_text;
	public Transform graze_text;
	public Transform life_text;

	// Use this for initialization
	void Start () {
		Transform p = Instantiate(player);
		p.position = new Vector2(-2,0);
		Debug.Log(p.GetComponent<Player>());

		Transform b = Instantiate(boss1);
		b.position = new Vector2(-2,3);
		b.GetComponent<Boss>().player = p;
	}

	// Update is called once per frame
	void Update () {

	}
}
