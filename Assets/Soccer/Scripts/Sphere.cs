
using UnityEngine;
using System.Collections;


public class Sphere : MonoBehaviour {

	public Transform shadowBall;


	void LateUpdate() {
	
		shadowBall.position = new Vector3( transform.position.x, 0.3f ,transform.position.z );
		shadowBall.rotation = Quaternion.identity;

	}
	
}
