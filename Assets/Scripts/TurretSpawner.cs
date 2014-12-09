using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretSpawner : MonoBehaviour {

	private bool buildTurret = false;

	private bool buildTurret2 = false;

	private float resources = 500f;

	private Camera mainCamera;

	private Cell cell;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		cell = gameObject.GetComponent ("Cell") as Cell;
	}
	
	// Update is called once per frame
	void Update () {
		resources += (Time.deltaTime * 10f);
		if (Input.GetMouseButtonDown (0) && !cell.gameOver) {
			placeTurret();
				}
	}

	void OnGUI () {
		if(GUI.Button(new Rect(20,40,150,20), "Build Turret [B] - 100") || Input.GetKeyDown(KeyCode.B)) {
			buildTurret = true;
		}
		if(GUI.Button(new Rect(20,80,150,20), "Build Turret [N] - 150") || Input.GetKeyDown(KeyCode.N)) {
			buildTurret2 = true;
		}
		GUI.Box (new Rect (Screen.width - 200, 40, 150, 20), "Resources: " + (int)resources);
	}
	
	void placeTurret () {
		Vector2 location = mainCamera.ScreenToWorldPoint (Input.mousePosition);
		if (buildTurret && resources >= 100) {
			GameObject go = (GameObject)Resources.Load ("TurretBase");
			GameObject tr = (GameObject)GameObject.Instantiate (go, location, Quaternion.identity);
			resources -= 100;
			buildTurret = false;
		}
		if (buildTurret2 && resources >= 150) {
			GameObject go = (GameObject)Resources.Load ("TurretBase2");
			GameObject tr = (GameObject)GameObject.Instantiate (go, location, Quaternion.identity);
			resources -= 150;
			buildTurret2 = false;
		}
	}

}
