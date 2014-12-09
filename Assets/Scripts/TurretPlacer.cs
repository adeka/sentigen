using UnityEngine;
using System.Collections;

public class TurretPlacer : MonoBehaviour {

	const int TURRET_PRICE = 20;

	public static int cash = 40;

	public static TurretPlacer instance;

	public LayerMask mask;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TryPlaceTurret();	
	}

	public static void AddCash(int c){
		cash += c;
	}

	Vector3 GetCollisionWithCell(){
		Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Ray ray = new Ray(v, Vector3.forward);
		RaycastHit2D rHit = Physics2D.GetRayIntersection(ray, 100, mask);
		
		if(rHit.collider != null){
			Debug.Log("Hit1");
			GameObject go = rHit.collider.gameObject;
			if(go != null){
				Debug.Log("Hit2");
				GameObject outerCell = go.transform.parent.gameObject;
				if(outerCell != null){
					Debug.Log("Hit3");
					return rHit.point;
				}
			}
		}
		
		return Vector2.zero;
	}

	void TryPlaceTurret(){
		if(Input.GetMouseButtonDown(0) && cash >= TURRET_PRICE){
			Debug.Log ("Stage 1");
			Vector2 turretPos = GetCollisionWithCell();

			if(turretPos != Vector2.zero){
				Debug.Log ("Stage 2");
				cash -= TURRET_PRICE;
				PlaceTurret(turretPos);
			}
		}
	}

	void PlaceTurret(Vector2 pos){		
		GameObject go = (GameObject)Resources.Load ("TurretBase");
		GameObject tu = (GameObject)GameObject.Instantiate (go, pos, Quaternion.identity);
	}
}
