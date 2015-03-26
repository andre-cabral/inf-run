using UnityEngine;
using System.Collections;

public class OneWayPlatform : MonoBehaviour {

	private Transform groundedAPosition;

	void Awake(){
		groundedAPosition = GameObject.FindGameObjectWithTag(Tags.groundedA).transform;
	}


	// Update is called once per frame
	void FixedUpdate () {
		if(groundedAPosition.position.y > gameObject.collider2D.bounds.max.y && gameObject.layer != Layers.floor){
			gameObject.layer = Layers.floor;
		}else if(groundedAPosition.position.y <= gameObject.collider2D.bounds.max.y && gameObject.layer != Layers.floorAbove){
			gameObject.layer = Layers.floorAbove;
		}
	}
}
