using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour {

    public GameObject objectToSpawn;
	
	void Start () {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerClickDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnPointerClickDelegate(PointerEventData data) {
        Debug.Log("spawn" + data);
    }
}
