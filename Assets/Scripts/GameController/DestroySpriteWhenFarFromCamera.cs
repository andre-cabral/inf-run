using UnityEngine;
using System.Collections;

public class DestroySpriteWhenFarFromCamera : MonoBehaviour {
	public float offset = 6f;
	private Camera cam;
	private Transform objectTransform;
	private float spriteWidth;

	void Awake(){
		cam = Camera.main;
		objectTransform = transform;
	}
	
	void Start () {
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteWidth = spriteRenderer.bounds.max.x - spriteRenderer.bounds.min.x;
	}
	
	void Update () {
		CheckToDestroyThisSprite();
	}

	void CheckToDestroyThisSprite(){
			//half the horizontal size of the screen
			//used to discover the camera border position
			//(because the camera.position return the camera center position)
			float cameraHorizontalSize = cam.orthographicSize * Screen.width/Screen.height;
			
			//half the width to discover the sprite border
			//(because the sprite.position return the center of the sprite)
			//the cameraHorizontalSize is used because on the if below we use the center of the camera
			float spriteRight = (objectTransform.position.x + spriteWidth/2);
			float spriteLeft = (objectTransform.position.x - spriteWidth/2);
			
			if(spriteRight < cam.transform.position.x  - cameraHorizontalSize - offset ){
				DestroyThisSprite();					
			}				
			
			if(spriteLeft > cam.transform.position.x + cameraHorizontalSize + offset ){
			DestroyThisSprite();
			}
	}

	void DestroyThisSprite(){
		Destroy(gameObject);
	}

}
