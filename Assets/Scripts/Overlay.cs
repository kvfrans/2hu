using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour {

	public enum characters { REIMU, MARISA, PATCHOULI, ALICE };

	private Vector2 direction_vector = new Vector2(1, 2);
	private float speed = 6.0f;
	private float time = 0;

	public GameObject mainCamera;
	public GameObject camera2;



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		move();
		updateSpeed();
		

	}

	void move () {

		time += Time.deltaTime;
		transform.Translate(direction_vector*speed*Time.deltaTime*Helper.Instance.gameSpeed);

	// // the syntax is GameObject.GetComponent<Overlay> ().changeCamera();
	// void changeCamera () {

	// 	mainCamera.GetComponent<Camera>().active = !mainCamera.GetComponent<Camera>().active;
 //    	camera2.GetComponent<Camera>().active = !camera2.GetComponent<Camera>().active;


	}


	void updateSpeed () {

		speed = (float) (Mathf.Pow(time-3, 2)/20 + 0.5);

	}
	// // the syntax is GameObject.GetComponent<Overlay> ().changeCamera();
	// void changeCamera () {

	// 	mainCamera.GetComponent<Camera>().active = !mainCamera.GetComponent<Camera>().active;
 //    	camera2.GetComponent<Camera>().active = !camera2.GetComponent<Camera>().active;

	// }

	// // returns the camera that is currently active
	// GameObject checkCamera () {
	// 	if(mainCamera.GetComponent<Camera>().active) return mainCamera;
	// 	else return camera2;
	// }

	// // returns the camera that is currently active
	// GameObject checkCamera () {
	// 	if(mainCamera.GetComponent<Camera>().active) return mainCamera;
	// 	else return camera2;
	// }



	// // the syntax is GameObject.GetComponent<Overlay> ().changeCamera();
	// void changeCamera () {

	// 	mainCamera.GetComponent<Camera>().active = !mainCamera.GetComponent<Camera>().active;
 	//   	camera2.GetComponent<Camera>().active = !camera2.GetComponent<Camera>().active;

	// }

	// // returns the camera that is currently active
	// GameObject checkCamera () {

	// 	if(mainCamera.GetComponent<Camera>().active) return mainCamera;
	// 	else return camera2;

	// }

}