using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	int hp = 10;

	public static Cell instance;

	public bool gameOver = false;

	public float timer = 20f;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0 && !gameOver) {
				timer -= Time.deltaTime;
				}
	}

	void OnGUI () {
		GUI.Box (new Rect (20, Screen.height - 50, 150, 20), "Cell HP: " + hp);
		if (gameOver) {
			GUI.Box (new Rect (Screen.width/2 - 100, Screen.height/4, 200, 200), "Game Over");
				}
		if (timer <= 0) {
			GUI.Box (new Rect (Screen.width/2 - 100, Screen.height/4, 200, 200), "Win!");
		}
		GUI.Box (new Rect (Screen.width - 200, Screen.height - 50, 150, 20), "Time: " + (int)timer);
	} 

	public static Vector3 GetLoc(){
		return instance.transform.position;
	}

	public void Damage(){
		if (timer > 0 && !gameOver) {
				hp--;
				if (hp <= 0) {
					gameOver = true;
					//Debug.Log("Game Over");
						}
				}
	}
}
