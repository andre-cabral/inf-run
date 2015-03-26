using UnityEngine;
using System.Collections;

public class FixedY : MonoBehaviour {

	void Update () {
		transform.position = new Vector3(transform.position.x, 0, transform.position.z);
	}
}
