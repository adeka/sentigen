﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public float delayMin = 0;
	public float delayMax = 3;
	float remainingDelay = 1;

	public float spawnDist = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		remainingDelay = remainingDelay - Time.deltaTime;
		if(remainingDelay <= 0){
			Spawn();
		}
	}

	public void Spawn(){
		remainingDelay = Random.Range (delayMin, delayMax);

		Vector2 spawnLoc = (Vector2)transform.position + GetUnitOncircle (Random.Range (0, 360), 1) * spawnDist;

		GameObject go = (GameObject)Resources.Load ("Enemy");
		GameObject en = (GameObject)GameObject.Instantiate (go, spawnLoc, Quaternion.identity);
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