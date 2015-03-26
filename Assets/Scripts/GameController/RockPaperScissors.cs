using UnityEngine;
using System.Collections;

public class RockPaperScissors : MonoBehaviour {

	//public enum types {rock = "Rock", paper = "Paper", scissors = "Scissors"};
	public const string rock = "Rock";
	public const string paper = "Paper";
	public const string scissors = "Scissors";

	public const string weaponWin = "Win";
	public const string weaponDraw = "Draw";
	public const string weaponLose = "Lose";




	public static string WeaponResult(string weaponType, string enemyType){

		if(weaponType == rock && enemyType == paper){
			return weaponLose;
		}
		if(weaponType == rock && enemyType == scissors){
			return weaponWin;
		}

		if(weaponType == paper && enemyType == rock){
			return weaponWin;
		}
		if(weaponType == paper && enemyType == scissors){
			return weaponLose;
		}

		if(weaponType == scissors && enemyType == rock){
			return weaponLose;
		}
		if(weaponType == scissors && enemyType == paper){
			return weaponWin;
		}

		return weaponDraw;

	}


}