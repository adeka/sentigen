using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretSpawner : MonoBehaviour {

	private bool buildTurret = false;

	private int resources = 900;

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
		if(GUI.Button(new Rect(20,40,150,20), "Build Turret [B]") || Input.GetKeyDown(KeyCode.B)) {
			buildTurret = true;
		}
		GUI.Box (new Rect (Screen.width - 200, 40, 150, 20), "Resources: " + resources);
	}
	
	void placeTurret () {
		Vector2 location = mainCamera.ScreenToWorldPoint (Input.mousePosition);
		if (buildTurret && resources >= 100) {
			GameObject go = (GameObject)Resources.Load ("TurretBase");
			GameObject tr = (GameObject)GameObject.Instantiate (go, location, Quaternion.identity);
			resources -= 100;
			//print ("Turret created");
			buildTurret = false;
		}
	}

}
