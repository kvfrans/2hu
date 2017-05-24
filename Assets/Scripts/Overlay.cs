using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour {

	public GameObject mainCamera;
	public GameObject camera2;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {



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

}
