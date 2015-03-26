using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerScore : MonoBehaviour {

	private int score = 0;
	private Text scoreNumber;
	private GameControllerDifficulty difficultyController;

	void Awake () {
		scoreNumber = GameObject.FindGameObjectWithTag(Tags.scoreNumber).GetComponent<Text>();
		difficultyController = GetComponent<GameControllerDifficulty>();
	}

	public void addScore(int scoreToAdd){
		score += scoreToAdd;
		updateScoreNumber();
		updateDifficulty();
	}

	public void subtractScore(int scoreToSubtract){
		score -= scoreToSubtract;
		if(score < 0){
			score = 0;
		}
		updateScoreNumber();
	}

	void updateScoreNumber(){
		scoreNumber.text = score.ToString();
	}

	void updateDifficulty(){
		if(score != 0){
			if(difficultyController.getDifficultyLevel() < Mathf.RoundToInt(score/10)){
				difficultyController.setDifficultyLevel(Mathf.RoundToInt(score/10));
			}
		}
	}
}
