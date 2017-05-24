using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cutscene : MonoBehaviour {

	// Transform references
	public Transform textbox;
	public Transform name;
	public Transform dialogue;
	public Transform pic;

	string message = "";
	int charadjust = 0;

	float timer = 0.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update ()
	{
		if(charadjust < message.Length)
		{
			timer += Time.deltaTime;
			if(timer > 0.02f)
			{
				timer = 0.0f;
				charadjust++;
			}
			dialogue.GetComponent<Text>().text = message.Substring(0, charadjust);
		}
	}

	public void startCutscene(string picname, string charname, string message_in)
	{
		message = message_in;
		name.GetComponent<Text>().text = charname;
		dialogue.GetComponent<Text>().text = "";
	}
}
