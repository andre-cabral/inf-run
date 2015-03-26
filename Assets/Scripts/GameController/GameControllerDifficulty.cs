using UnityEngine;
using System.Collections;

public class GameControllerDifficulty : MonoBehaviour {

	public GameObject player;
	private Movement playerMovementScript;
	public int difficultyLevel = 0;

	void Awake(){
		playerMovementScript = player.GetComponent<Movement>();
	}

	void changeToLevel(int level){
		switch(level){
			case 1:
				addPlayerSpeed(1f);
			break;

			case 2:
				addPlayerSpeed(1f);
			break;

			case 3:
				addPlayerSpeed(1f);
			break;
		}
	}

	void addPlayerSpeed(float speedToAdd){
		if( (playerMovementScript.currentSpeed + speedToAdd) <= playerMovementScript.maxSpeed){
			playerMovementScript.currentSpeed += speedToAdd;
		}else{
			playerMovementScript.currentSpeed = playerMovementScript.maxSpeed;
		}
	}

	void changeSpawnersLevel(){
		GameObject[] spawners = GameObject.FindGameObjectsWithTag(Tags.spawner);

		foreach(GameObject spawner in spawners){
			Spawner spawnerScript = spawner.GetComponent<Spawner>();
			if(spawnerScript.spawnerAppearsOnLevel < difficultyLevel){
				Destroy(spawner);
			}
			if(spawnerScript.spawnerAppearsOnLevel == difficultyLevel){
				spawner.SetActive(true);
			}
		}
	}

	public int getDifficultyLevel(){
		return difficultyLevel;
	}

	public void setDifficultyLevel(int difficultyLevel){
		this.difficultyLevel = difficultyLevel;
		changeToLevel(this.difficultyLevel);
	}
}
