using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour {

    public GameObject objectToSpawn;
	
	void Start () {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { OnPointerClickDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnPointerClickDelegate(PointerEventData data) {
        GameObject spawnedObj = (GameObject) Object.Instantiate(objectToSpawn, data.pointerPressRaycast.worldPosition, Quaternion.identity);
        spawnedObj.SetActive(true);
    }
}
