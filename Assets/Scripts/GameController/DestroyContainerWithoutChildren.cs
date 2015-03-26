using UnityEngine;
using System.Collections;

public class DestroyContainerWithoutChildren : MonoBehaviour {
	private Transform objectTransform;

	void Awake(){
		objectTransform = transform;
	}

	void Update () {
		if(!hasChildren()){
			Destroy(gameObject);
		}
	}

	bool hasChildren()
	{
		int childCount = 0;
		foreach (Transform x in objectTransform)
		{
			childCount ++;
		}

		if(childCount > 0){
			return true;
		}else{
			return false;
		}

	}

}
