using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSchmooze : MonoBehaviour {

	public float spawnInterval = 5.0f;
	public GameObject objectToSpawn;
	private bool isBlockingSpawner = false;

    // Use this for initialization
    void Start () {
		StartCoroutine(SpawnNewSchmooze());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnNewSchmooze() {
		while (this.transform.gameObject.activeSelf) {
			yield return new WaitForSeconds(spawnInterval); //wait for spawnInterval before continuing
			
			// Debug.Log("Spawning schmooze");
			Vector3 spawnPos = findNextSpawnPosition();
			if (!spawnPos.Equals(Vector3.negativeInfinity)) {
				// Debug.Log("Spawnpos " + spawnPos);
				GameObject newSchmooze = Object.Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
				newSchmooze.SetActive(true);
            }
        }
	}

	private Vector3 findNextSpawnPosition() {
		Vector3 foundPos = Vector3.negativeInfinity;
		int spawnDist = 1;

		for (int i = 0; i < 8; i++) {
			transform.Rotate(Vector3.up * 45f * i);
	        Vector3 fwd = transform.forward;

	        RaycastHit hitInfo;

	        if (Physics.Raycast(transform.position, fwd, out hitInfo, spawnDist)) {
	            Debug.DrawRay(transform.position, fwd * spawnDist, Color.red);
	            // print("There is something in front of the object! " + hitInfo.transform.gameObject.name);
	        } else {
	            Debug.DrawRay(transform.position, fwd * spawnDist, Color.red);
	            foundPos = transform.position + fwd * spawnDist;
	            break;
	        }
		}

		transform.Rotate(Vector3.up);
		return foundPos;
	}

	public void convertToBlockingSpawner() {
		if (!isBlockingSpawner) {
			isBlockingSpawner = true;
			Debug.Log("Converted to blocking schmooze spawner");
		}
	}

	// void FixedUpdate() {
	// 	transform.Rotate(Vector3.up * 35f * Time.deltaTime);
 //        Vector3 fwd = transform.forward;

 //        if (Physics.Raycast(transform.position, fwd, 3)){
 //        	Debug.DrawRay(transform.position, fwd * 3, Color.red);
 //            print("There is something in front of the object!");
 //        } else {
 //        	Debug.DrawRay(transform.position, fwd * 3, Color.red);
 //        }
 //    }
}
