using UnityEngine;
using System.Collections;

public class Sombra_Script : MonoBehaviour {
	
	
	public Vector3 prueba;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		transform.rotation = Quaternion.Euler( -90, 0, 0);
		
	}
}
