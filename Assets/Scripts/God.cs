using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class God : MonoBehaviour {

	// Prefab references
	public Transform player;
	public Transform boss1;
	public Transform boss2;

	//GUI references
	public Transform score_text;
	public Transform graze_text;
	public Transform life_text;
	public Transform boss_health;

	// Real references
	Transform player_tr;
	Transform boss_tr;

	// Script references
	Player player_script;
	Boss boss_script;

	// Use this for initialization
	void Start () {
		player_tr = Instantiate(player);
		player_tr.position = new Vector2(-2,0);
		player_script = player_tr.GetComponent<Player>();

		Transform boss_tr = Instantiate(boss1);
		boss_tr.position = new Vector2(-2,3);
		boss_script = boss_tr.GetComponent<Boss>();
		boss_script.player = player_tr;

		Helper.Instance.makeCutscene("nitori", "Nitori Kawashiro", "hmmmmmmmmmm if i take a look at my graphing calculator over here let me just say that i can clearly see that MARISA STOLE IT");
	}

	// Update is called once per frame
	void Update () {
		updateGUI();
	}

	void updateGUI()
	{
		score_text.GetComponent<Text>().text = "Score: " + 0;
		graze_text.GetComponent<Text>().text = "Graze: " + player_script.graze;
		life_text.GetComponent<Text>().text = "Life: " + player_script.lives;
		boss_health.localScale = new Vector2((boss_script.currentHealth * 22.0f) / boss_script.startingHealth, 1);
	}
}
