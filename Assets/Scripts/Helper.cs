using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {

	public static Helper Instance;

	void Awake()
	{
		Instance = this;
	}

	public void clearBullets()
	{

	}
}
