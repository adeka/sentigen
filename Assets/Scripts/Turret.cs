using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public float range = 200;
	public float bulletVel = .00002f;
	public float fireRate = 1;

	float fireRateRemaining = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TryFire ();
		transform.rotation = GetRotation (transform.position, GetPosOfNearestEnemy ());
	}

	void TryFire(){
		if (fireRateRemaining <= 0) {
			Vector2 target = GetPosOfNearestEnemy();

			if(target != (Vector2)transform.position){
				FireAt(target);
			}
		} else {
			fireRateRemaining = fireRateRemaining - Time.deltaTime;
		}
	}

	Vector2 GetPosOfNearestEnemy(){
		GameObject closest = gameObject;
		float closestDist = range;

		foreach(GameObject en in EnemySpawner.enemies){
			if(en != null){
				float dist = Vector2.Distance(transform.position, en.transform.position);
				if(dist < range && dist < closestDist){
					closestDist = dist;
					closest = en;
				}
			}
		}

		return closest.transform.position;
	}

	void FireAt(Vector2 pos){
		fireRateRemaining = fireRate;

		Vector2 spawnLoc = (Vector2)transform.position;
		
		GameObject go = (GameObject)Resources.Load ("Bullet");
		GameObject bu = (GameObject)GameObject.Instantiate (go, spawnLoc, Quaternion.identity);
		Bullet b = bu.GetComponent<Bullet> ();

		b.vel = (pos - (Vector2)transform.position).normalized * bulletVel;
	}

	Quaternion GetRotation(Vector2 pos, Vector2 targ){
		Vector3 vectorToTarget = targ - pos;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle - 90, Vector3.forward);
		
		return q;
		//transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
	}
}
