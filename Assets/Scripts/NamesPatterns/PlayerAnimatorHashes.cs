using UnityEngine;
using System.Collections;

public class PlayerAnimatorHashes : MonoBehaviour {

	public int yVelocity;
	public int alive;
	public int attacking;
	public int jumping;
	
	void Awake() {
		yVelocity = Animator.StringToHash("yVelocity");
		alive = Animator.StringToHash("Alive");
		attacking = Animator.StringToHash("Attacking");
		jumping = Animator.StringToHash("Jumping");
	}
}
