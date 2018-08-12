using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour {

    public GameObject spawnerPrefab;
    public GameObject nonSpawnerPrefab;

    public float spawnRadius = 15f;
	
	void Start () {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { OnPointerClickDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnPointerClickDelegate(PointerEventData data) {
    	Vector3 pointerPos = data.pointerPressRaycast.worldPosition;
    	if (inRangeOfSpawner(pointerPos)) {
    		Debug.Log("In range of spawner, spawning non-spawner");
			GameObject spawnedObj = (GameObject) Object.Instantiate(nonSpawnerPrefab, pointerPos, Quaternion.identity);
	        spawnedObj.SetActive(true);
    	} else {
    		Debug.Log("Out of range of spawner, spawning spawner");
	        GameObject spawnedObj = (GameObject) Object.Instantiate(spawnerPrefab, pointerPos, Quaternion.identity);
	        spawnedObj.SetActive(true);
    	}
    }

    private bool inRangeOfSpawner(Vector3 position) {
    	GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
    	for (int i = 0; i < spawners.Length; i++) {
    		float distance = Vector3.Distance(spawners[i].transform.position, position);
    		//Debug.Log("Distance is " + distance + " between " + spawners[i].name + " and pointer");
    		if (spawners[i].activeSelf && distance <= spawnRadius) {
    			return true;
    		}
    	}
    	return false;
    }
}
