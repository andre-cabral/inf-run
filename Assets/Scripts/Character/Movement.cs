using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float initialSpeed = 5f;
	public float minSpeed = 3f;
	public float maxSpeed = 10f;
	public float jumpForce = 500f;
	private bool grounded = false;
	public float currentSpeed;
	private Transform objectTransform;
	private bool attacking = false;
	private GameObject gameController;
	private GameController gameControllerScript;
	private Animator playerAnimator;
	private PlayerAnimatorHashes playerAnimatorHashes;

	void Awake(){
		gameController = GameObject.FindGameObjectWithTag(Tags.gameController);
		gameControllerScript = gameController.GetComponent<GameController>();
		playerAnimator = gameObject.GetComponent<Animator>();
		playerAnimatorHashes = gameObject.GetComponent<PlayerAnimatorHashes>();
	}

	void Start () {
		objectTransform = transform;
		currentSpeed = initialSpeed;
	}
	
	void Update () {
		GroundCheck();
		if(gameControllerScript.getIsPlayerAlive()){
			transform.Translate( Vector3.right * currentSpeed * Time.deltaTime );
		}else{
			playerAnimator.SetBool(playerAnimatorHashes.alive, false);
		}
		yVelocityAnimation();
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.layer == Layers.floor){
			grounded = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == Tags.enemy && !attacking){
			Debug.Log("player HIT player script");
		}
		if(other.tag == Tags.coin){
			Debug.Log("player got a COIN, player script");
		}
	}

	public void GroundCheck(){
		if(objectTransform.rigidbody2D.velocity.y != 0){
			grounded = false;
		}
	}

	public void Jump(){
		if(grounded && gameControllerScript.getIsPlayerAlive()){
			playerAnimator.SetTrigger(playerAnimatorHashes.jumping);
			grounded = false;
			rigidbody2D.AddForce(Vector2.up * jumpForce);
		}
	}

	private void yVelocityAnimation(){
		playerAnimator.SetFloat(playerAnimatorHashes.yVelocity, objectTransform.rigidbody2D.velocity.y);
	}

	public void setAttacking(bool attacking){
		this.attacking = attacking;
		playerAnimator.SetBool(playerAnimatorHashes.attacking, attacking);
	}
}
