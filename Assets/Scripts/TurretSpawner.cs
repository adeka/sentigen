using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretSpawner : MonoBehaviour {

	private bool buildTurret = false;

	private Camera mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			placeTurret();
				}
	}

	void OnGUI () {
		if(GUI.Button(new Rect(20,40,80,20), "Build Turret")) {
			buildTurret = true;
		}
	}
	
	void placeTurret () {
		Vector2 location = mainCamera.ScreenToWorldPoint (Input.mousePosition);
		if (buildTurret) {
			GameObject go = (GameObject)Resources.Load ("TurretBase");
			GameObject tr = (GameObject)GameObject.Instantiate (go, location, Quaternion.identity);
			print ("Turret created");
			buildTurret = false;
		}
	}

}
