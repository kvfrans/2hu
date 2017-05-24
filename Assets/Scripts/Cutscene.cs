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

	// Sprite references
	public Sprite nitori;
	public Sprite cirno;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update ()
	{
		if(charadjust < message.Length)
		{
			timer += Helper.Instance.globalDeltaTime();
			if(timer > 0.003f)
			{
				timer = 0.0f;
				charadjust++;
			}
			dialogue.GetComponent<Text>().text = message.Substring(0, charadjust);
		}

		if(Input.GetKeyDown("z"))
		{
			if(charadjust < message.Length)
			{
				charadjust = message.Length;
				dialogue.GetComponent<Text>().text = message;
			}
			else
			{
				Helper.Instance.resumeGame();
				Destroy(gameObject);
			}
		}
	}

	public void startCutscene(string picname, string charname, string message_in)
	{
		Helper.Instance.pauseGame();
		message = message_in;
		name.GetComponent<Text>().text = charname;
		dialogue.GetComponent<Text>().text = "";

		Sprite spriteimg = nitori;
		switch(picname)
		{
			case "nitori":
				spriteimg = nitori;
				break;
			case "cirno":
				spriteimg = cirno;
				break;

		}
		pic.GetComponent<SpriteRenderer>().sprite = spriteimg;
	}
}
