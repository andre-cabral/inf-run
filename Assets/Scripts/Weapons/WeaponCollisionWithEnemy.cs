using UnityEngine;
using System.Collections;

public class WeaponCollisionWithEnemy : MonoBehaviour {

	private GameObject player;
	public string weaponType;

	void Awake(){
		player = GameObject.FindGameObjectWithTag(Tags.player);
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if(other.tag == Tags.enemy){
			EnemyCollisions enemyCollision = other.gameObject.GetComponent<EnemyCollisions>();
			string result = RockPaperScissors.WeaponResult(weaponType, enemyCollision.enemyType);

			if(result == "Win"){
				Debug.Log("player WIN weapon script");
			}
			if(result == "Draw"){
				Debug.Log("player DRAW weapon script");
			}
			if(result == "Lose"){
				Debug.Log("player LOSE weapon script");
			}

		}
	}

}
