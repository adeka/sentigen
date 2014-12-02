using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Vector2 vel;
	public float life = 3.0f;

	void Update(){
		transform.position = (Vector2)transform.position + vel * Time.deltaTime;

		life = life - Time.deltaTime;

		if (life <= 0) {
			GameObject.Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Enemy enemy = other.gameObject.GetComponent<Enemy> ();
		
		if(enemy != null){
			GameObject.Destroy(enemy.gameObject);
			GameObject.Destroy(this.gameObject);
		}
	}
}
