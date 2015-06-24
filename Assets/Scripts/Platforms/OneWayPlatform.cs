using UnityEngine;
using System.Collections;

public class OneWayPlatform : MonoBehaviour {

	private Transform player;

	void Awake(){
		player = GameObject.FindGameObjectWithTag(Tags.player).transform;
	}


	// Update is called once per frame
	void FixedUpdate () {
		if(player.collider2D.bounds.min.y > gameObject.collider2D.bounds.max.y && gameObject.layer != Layers.floor){
			gameObject.layer = Layers.floor;
		}else if(player.collider2D.bounds.min.y <= gameObject.collider2D.bounds.max.y && gameObject.layer != Layers.floorAbove){
			gameObject.layer = Layers.floorAbove;
		}
	}
}
