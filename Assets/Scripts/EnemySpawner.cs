using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	public static List<GameObject> enemies = new List<GameObject> ();

	public float delayMin = 0;
	public float delayMax = 3;
	float remainingDelay = 1;

	public float spawnDist = 10;

	private Cell cell;

	// Use this for initialization
	void Start () {
		cell = gameObject.GetComponent ("Cell") as Cell;
	}
	
	// Update is called once per frame
	void Update () {
		remainingDelay = remainingDelay - Time.deltaTime;
		if(remainingDelay <= 0 && !cell.gameOver && cell.timer > 0){
			Spawn();
		}
	}

	public void Spawn(){
		remainingDelay = Random.Range (delayMin, delayMax);
		delayMax = remainingDelay;

		Vector2 spawnLoc = (Vector2)transform.position + GetUnitOncircle (Random.Range (0, 360), 1) * spawnDist;

		GameObject go = (GameObject)Resources.Load ("Enemy");
		GameObject en = (GameObject)GameObject.Instantiate (go, spawnLoc, Quaternion.identity);

		enemies.Add (en);
	}

	Vector2 GetUnitOncircle(float angleDegrees, float radius) {
		// initialize calculation variables
		float _x = 0;
		float _y = 0;
		float angleRadians = 0;
		Vector2 _returnVector;

		// convert degrees to radians
		angleRadians = angleDegrees * Mathf.PI / 180.0f;

		// get the 2D dimensional coordinates
		_x = radius * Mathf.Cos (angleRadians);
		_y = radius * Mathf.Sin (angleRadians);

		// derive the 2D vector
		_returnVector = new Vector2 (_x, _y);

		// return the vector info
		return _returnVector;
	}
}
