using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public int spawnerAppearsOnLevel = 0;
	public GameObject[] objectsArray;
	public float minimumSpawnTime = 1f;
	public float maximumSpawnTime = 2f;
	public float offsetFromCamera = 6f;
	private Camera cam;
	private Transform objectTransform;
	private float cameraHorizontalSize;
	public float delayToSpawnFirstObject = 1f;
	private float delayPassed = 0f;

	void Awake(){
		cam = Camera.main;
		objectTransform = transform;
	}

	void Start () {
		cameraHorizontalSize = cam.orthographicSize * Screen.width/Screen.height;
		Spawn ();
	}

	void Update(){
		FollowCameraOffscreenFromRight();
		delayPassed += Time.deltaTime;
	}

	
	void Spawn () {
		if(delayPassed >= delayToSpawnFirstObject){
			//The max value in Random.Range is EXCLUSIVE, so you have to put maximumNumber+1 in max.
			//(here its objectsArray.Lenght instead of objectsArray.Length-1)
			//The min value is INCLUSIVE, so its the exact minimum number
			Instantiate(objectsArray[Random.Range(0, objectsArray.Length)], transform.position, Quaternion.identity);
		}
		Invoke("Spawn", Random.Range(minimumSpawnTime, maximumSpawnTime));
	}

	void FollowCameraOffscreenFromRight(){
		float xPosition = cam.transform.position.x + (cameraHorizontalSize/2) + offsetFromCamera;
		objectTransform.position = new Vector3(xPosition, objectTransform.position.y, objectTransform.position.z);
	}
}
