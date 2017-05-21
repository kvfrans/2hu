using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 1;
	public float direction = 0;

	private Vector2 direction_vector;

	// Use this for initialization
	void Start ()
	{
		direction_vector = new Vector2(1,0);
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void setDirection(float dir)
	{
		direction = dir;
		direction_vector = new Vector(Mathf.Cos(dir * Mathf.Deg2Rad), Mathf.Sin(dir * Mathf.Deg2Rad))
	}


}
