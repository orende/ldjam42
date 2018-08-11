using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour {

    public GameObject objectToSpawn;
	// Use this for initialization
	void Start () {
        EventTrigger trigger = GetComponent<EventTrigger>();
    }

    public void SpawnAtPosition(PointerEventData data){
        Debug.Log("spawn " + data);
    }
}
