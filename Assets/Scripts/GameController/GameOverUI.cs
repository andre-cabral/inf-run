using UnityEngine;
using System.Collections;

public class GameOverUI : MonoBehaviour {

	public GameObject[] objectsToShowOnGameOver;
	public GameObject[] objectsToHideOnGameOver;
	private GameController gameController;

	void Awake () {
		gameController = gameObject.GetComponent<GameController>();
	}

	void Update () {
		if( !gameController.getIsPlayerAlive() ){
			foreach(GameObject obj in objectsToHideOnGameOver){
				obj.SetActive(false);
			}
			foreach(GameObject obj in objectsToShowOnGameOver){
				obj.SetActive(true);
			}
		}	
	}

	public void goToScene(string sceneName){
		Application.LoadLevel(sceneName);
	}
}
