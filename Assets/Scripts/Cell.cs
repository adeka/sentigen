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
