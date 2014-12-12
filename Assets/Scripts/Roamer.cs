using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Roamer : MonoBehaviour {
	//how much damage does this do
	public int damage = 50;
	
	public string target_tag = "Enemy";
	
	//what this is following
	GameObject target;

	//The distance to look for targets
	public float range = 100f;
	
	//how fast this moves
	public float speed = 100;

	// Use this for initialization
	void Start () {
		set_target ();
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null){
			set_target ();
		}
		else{
			move_simple ();
		}
	}


	void move_simple(){
		transform.position = Vector2.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
		transform.rotation = GetRotation (transform.position, target.transform.position);
	}

	Quaternion GetRotation(Vector2 pos, Vector2 targ){
		Vector3 vectorToTarget = targ - pos;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle - 90, Vector3.forward);		
		return q;
	}


	//finds the closest valid target and sets this object's "target" property to point to what it finds
	void set_target(){
		//get an array of things tagged as enemies
		GameObject[] possible_targets_array = GameObject.FindGameObjectsWithTag (target_tag);
		
		//if it wasn't able to find any objects with that tag at any range, complain and commit suicide
		if (possible_targets_array.Length == 0) {
			print ("ALERT  |  ROAMER:  no targets found with target_tag  " + target_tag);
			return;
		}
		
		//turn the array into a List because arrays are tedious as hell to work with
		List<GameObject> possible_targets = new List<GameObject>();
		foreach (GameObject element in possible_targets_array) {
			possible_targets.Add(element);
		}

		target = find_closest_possible_target(possible_targets[0], possible_targets);

		//if it went through all possible targets and didn't find a valid one, commit suicide
		if(target == null){
			print ("ALERT  |  ROAMER:  No valid targets found with target_tag  " + target_tag);
		}
	}
	
	private GameObject find_closest_possible_target(GameObject g_closest_possible_target, List<GameObject> g_possible_targets){
		GameObject temp_closest_possible_target = g_closest_possible_target;
		float distance_to_element = 0f;
		float distance_to_closest_possible_target = 0f;
		
		foreach (GameObject element in g_possible_targets) {
			//calculate distances
			distance_to_element = (element.transform.position - transform.position).magnitude;
			distance_to_closest_possible_target = (temp_closest_possible_target.transform.position - transform.position).magnitude;
			
			//if it finds an element closer or the same distance, make it the closest_possible_target
			if (distance_to_element <= distance_to_closest_possible_target){
				temp_closest_possible_target = element;
			}
		}
		return temp_closest_possible_target;
	}

	void OnTriggerEnter2D(Collider2D other){
		//hurt 
		Enemy enemy = other.gameObject.GetComponent<Enemy> ();
		if(enemy != null){
			GameObject.Destroy(enemy.gameObject);

		}
		print (other.gameObject.tag);
		set_target ();
	}
}

