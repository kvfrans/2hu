using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// enums
	public enum bullet_type { PLAYER, ENEMY, NEUTRAL };

	// public set parameters
	public float speed = 1;
	public float direction = 0;
	public bullet_type type = bullet_type.ENEMY;
	public bool destroy_on_hit = true;

	// private use variables
	private Vector2 direction_vector;

	// Use this for initialization
	void Start ()
	{
		direction_vector = new Vector2(Mathf.Cos(direction * Mathf.Deg2Rad), Mathf.Sin(direction * Mathf.Deg2Rad));
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate(direction_vector*speed*Time.deltaTime);
	}

	public void setDirection(float dir)
	{
		direction = dir;
		direction_vector = new Vector2(Mathf.Cos(dir * Mathf.Deg2Rad), Mathf.Sin(dir * Mathf.Deg2Rad));
	}

	public void HitPlayer()
	{
		if(destroy_on_hit)
		{
			Destroy(gameObject);
		}
	}

}
