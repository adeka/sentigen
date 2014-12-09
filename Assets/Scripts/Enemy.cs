using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed = 100;
	public int killValue = 1;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, Cell.GetLoc (), speed * Time.deltaTime);

		transform.rotation = GetRotation (transform.position, Cell.GetLoc ());//new Quaternion(0, 0, Vector2.Angle ((Vector2)transform.position, Cell.GetLoc()), 0);

		//transform.LookAt (Cell.instance.transform);

		//Vector2 o = transform.position - Cell.GetLoc();
		//Quaternion rotation = Quaternion.LookRotation (o);

		//transform.rotation = rotation;
	}

	void OnTriggerEnter2D(Collider2D other){
		Cell cell = other.gameObject.GetComponent<Cell> ();

		if(cell != null){
			cell.Damage();
			GameObject.Destroy(this.gameObject);
		}

		Turret turret = other.gameObject.GetComponent<Turret>();

		if(turret != null){
			GameObject.Destroy(turret.gameObject);
			GameObject.Destroy(this.gameObject);
		}
	}

	Quaternion GetRotation(Vector2 pos, Vector2 targ){
		Vector3 vectorToTarget = targ - pos;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle - 90, Vector3.forward);

		return q;
		//transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
	}
}
