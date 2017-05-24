using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {

	public static Helper Instance;

	// Prefab references
	public Transform cutscene;

	void Awake()
	{
		Instance = this;
	}

	public void clearBullets()
	{

	}

	public void makeCutscene(string picname, string charname, string message)
	{
		Transform c = Instantiate(cutscene);
		c.position = new Vector3(-1.78f, -3.07f, -1f);
		c.GetComponent<Cutscene>().startCutscene(picname, charname, message);
	}
}
