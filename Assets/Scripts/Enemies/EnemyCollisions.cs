using UnityEngine;
using System.Collections;

public class EnemyCollisions : MonoBehaviour {

	public string enemyType;
	public int enemyPoints = 1;
	public int enemyPointsLostOnDraw = 1;
	private GameObject gameController;
	private GameController gameControllerScript;
	private GameControllerScore gameControllerScoreScript;

	void Awake(){
		gameController = GameObject.FindGameObjectWithTag(Tags.gameController);
		gameControllerScript = gameController.GetComponent<GameController>();
		gameControllerScoreScript = gameController.GetComponent<GameControllerScore>();
	}

	
	void OnTriggerEnter2D (Collider2D other) {
		if(other.tag == Tags.weapon){
			WeaponCollisionWithEnemy weaponCollision = other.gameObject.GetComponent<WeaponCollisionWithEnemy>();
			string result = RockPaperScissors.WeaponResult(weaponCollision.weaponType, enemyType);

			//The results returns if the PLAYER win, draw or lose, NOT IF THE ENEMY win, draw or lose.
			if(result == "Win"){
				Debug.Log("player WIN enemy script");
				gameControllerScoreScript.addScore(enemyPoints);
			}
			if(result == "Draw"){
				Debug.Log("player DRAW enemy script");
				gameControllerScoreScript.subtractScore(enemyPointsLostOnDraw);
			}
			if(result == "Lose"){
				Debug.Log("player LOSE enemy script");
				gameControllerScript.setIsPlayerAlive(false);
			}
			
			Destroy(gameObject);
		}

		if(other.tag == Tags.player){
			Debug.Log("player HIT enemy script");
			gameControllerScript.setIsPlayerAlive(false);
			Destroy(gameObject);
		}

	}
}
