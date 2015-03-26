using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public GameObject player;
	private Movement playerMovementScript;
	public GameObject rock;
	private bool rockButtonPressed = false;
	public GameObject paper;
	private bool paperButtonPressed = false;
	public GameObject scissors;
	private bool scissorsButtonPressed = false;
	//use the next two lines only WITH weaponDuration
	public float weaponDuration = 0.49f;
	private float durationTimePassed = 0f;
	private bool attacking = false;
	private GameObject gameController;
	private GameController gameControllerScript;


	void Awake(){
		playerMovementScript = player.GetComponent<Movement>();
		gameController = GameObject.FindGameObjectWithTag(Tags.gameController);
		gameControllerScript = gameController.GetComponent<GameController>();
	}


	void Update(){
		//use the next two ifs only with duration time
		if(attacking && durationTimePassed < weaponDuration){
			durationTimePassed += Time.deltaTime;
		}

		if(!rockButtonPressed && rock.activeSelf){
			endRock();
		}

		if(!paperButtonPressed && paper.activeSelf){
			endPaper();
		}

		if(!scissorsButtonPressed && scissors.activeSelf){
			endScissors();
		}

		if(!gameControllerScript.getIsPlayerAlive()){
			cleanWeapons();
		}

		/*
		if(durationTimePassed >= weaponDuration && !attacking){
			cleanWeapons();
			durationTimePassed = 0f;
		}
		*/
	}

	public void startRock(){
		rockButtonPressed = true;
		startWeapon(rock);
	}
	public void endRock(){
		if(durationTimePassed >= weaponDuration){
			endWeapon(rock);
		}
	}
	public void releasedRockButton(){
		rockButtonPressed = false;
	}

	public void startPaper(){
		paperButtonPressed = true;
		startWeapon(paper);
	}
	public void endPaper(){
		if(durationTimePassed >= weaponDuration){
			endWeapon(paper);
		}
	}
	public void releasedPaperButton(){
		paperButtonPressed = false;
	}

	public void startScissors(){
		scissorsButtonPressed = true;
		startWeapon(scissors);
	}
	public void endScissors(){
		if(durationTimePassed >= weaponDuration){
			endWeapon(scissors);
		}
	}
	public void releasedScissorsButton(){
		scissorsButtonPressed = false;
	}

	void startWeapon(GameObject weapon){
		if (gameControllerScript.getIsPlayerAlive()){
			cleanWeapons();
			//use the next line only WITH weaponDuration
			durationTimePassed = 0f;
			attacking = true;
			playerMovementScript.setAttacking(attacking);
			weapon.SetActive(true);
		}
	}
	void endWeapon(GameObject weapon){
		weapon.SetActive(false);
		if(!rockButtonPressed && !paperButtonPressed && !scissorsButtonPressed){
			attacking = false;
		}
		playerMovementScript.setAttacking(attacking);

		//use the next line only WITHOUT durationTimePassed
		//cleanWeapons();
	}

	void cleanWeapons(){
		rock.SetActive(false);
		paper.SetActive(false);
		scissors.SetActive(false);
	}

}
