using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifySpawner : MonoBehaviour {

	private GenerateSchmooze gs;

	void Start () {
		gs = transform.gameObject.GetComponent<GenerateSchmooze>();
	}
	
	void Update () {
		
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			gs.convertToBlockingSpawner();
		}
	}
}
