using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSchmooze : MonoBehaviour {

	public float spawnInterval = 5.0f;

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
			
			Debug.Log("Spawning schmooze");
			// findNextSpawnPosition();
		}
	}

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        
        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, fwd, out hitInfo, 3)) {
            Debug.DrawRay(transform.position, fwd * 3, Color.red);
            print("There is something in front of the object! " + hitInfo.transform.gameObject.name);
        } else {
            Debug.DrawRay(transform.position, fwd * 3, Color.red);
        }
    }
}
