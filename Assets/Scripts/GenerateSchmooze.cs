using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSchmooze : MonoBehaviour {

	public float spawnInterval = 5.0f;
	public GameObject objectToSpawn;

	private int spawnerType = 0; // 0 = normal spawner, 1 = blocking spawner
	private List<GameObject> spawns = new List<GameObject>();

    void Start () {
		StartCoroutine(SpawnNewSchmooze());
	}
	
	void Update () {
		
	}

	IEnumerator SpawnNewSchmooze() {
		while (this.transform.gameObject.activeSelf) {
			yield return new WaitForSeconds(spawnInterval); //wait for spawnInterval before running rest of method
			
			// Debug.Log("Spawning schmooze");
			Vector3 spawnPos = findNextSpawnPosition();
			if (!spawnPos.Equals(Vector3.negativeInfinity)) {
				// Debug.Log("Spawnpos " + spawnPos);
				GameObject newSchmooze = Object.Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
				if (spawnerType == 1) {
					newSchmooze.GetComponentInChildren(typeof(BlockingSchmooze)).gameObject.GetComponent<BoxCollider>().enabled = true;
				}
				spawns.Add(newSchmooze);
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

	public void changeSpawnerType() {
		if (spawnerType == 0) {
			spawnerType = 1;
			Debug.Log("Converted to blocking schmooze spawner");
			convertSpawnedSchmoozeToBlockingType();
		}
	}

	private void convertSpawnedSchmoozeToBlockingType() {
		foreach (GameObject comp in spawns) {
			comp.GetComponentInChildren(typeof(BlockingSchmooze)).gameObject.GetComponent<BoxCollider>().enabled = true;
		}
	}
}
