using UnityEngine;
using System.Collections;

public class CoinCollider : MonoBehaviour {

	public int coinPoints = 3;
	private GameObject gameController;
	private GameControllerScore gameControllerScoreScript;

	void Awake(){
		gameController = GameObject.FindGameObjectWithTag(Tags.gameController);
		gameControllerScoreScript = gameController.GetComponent<GameControllerScore>();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.tag == Tags.player){
			Debug.Log("player got a COIN, coin script");
			gameControllerScoreScript.addScore(coinPoints);
			Destroy(gameObject);
		}		
	}
}
