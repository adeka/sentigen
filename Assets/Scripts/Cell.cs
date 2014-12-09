using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	int hp = 10;

	public static Cell instance;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUI.Box (new Rect (20, Screen.height - 50, 150, 20), "Cell HP: " + hp);
	} 

	public static Vector3 GetLoc(){
		return instance.transform.position;
	}

	public void Damage(){
		hp--;
		if(hp <= 0){
			Debug.Log("Game Over");
		}
	}
}
