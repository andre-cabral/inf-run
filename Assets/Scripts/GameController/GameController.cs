using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private bool isPlayerAlive = true;

	public void setIsPlayerAlive(bool isPlayerAlive){
		this.isPlayerAlive = isPlayerAlive;
	}

	public bool getIsPlayerAlive(){
		return isPlayerAlive;
	}
}
