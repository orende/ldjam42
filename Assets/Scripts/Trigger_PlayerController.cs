using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_PlayerController : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        
        switch (this.GetComponentInParent<PlayerController_01>().equippedItem)
        {
            case 0:
                Debug.Log("CASE 0");
                if (other.gameObject.name == "Axe" || other.gameObject.name == "Axe(Clone)") { this.GetComponentInParent<PlayerController_01>().equippedItem = 1; Destroy(other.gameObject); }
                else if (other.gameObject.name == "Mop" || other.gameObject.name == "Mop(Clone)") { this.GetComponentInParent<PlayerController_01>().equippedItem = 2; Destroy(other.gameObject); }
                else if (other.gameObject.name == "WallBuilder" || other.gameObject.name == "WallBuilder(Clone)") { this.GetComponentInParent<PlayerController_01>().equippedItem = 3; Destroy(other.gameObject); }
                this.gameObject.SetActive(false);
                break;
            case 1:
                Debug.Log("CASE 1");
                if (other.gameObject.CompareTag("Destructable")) { Destroy(other.gameObject); }
                this.gameObject.SetActive(false);
                break;
            case 2:
                Debug.Log("CASE 2");
                if (other.gameObject.CompareTag("Schmooze")) { Destroy(other.gameObject); }
                this.gameObject.SetActive(false);
                break;

            default:
                Debug.Log("DEFAULT HAPPENING");
                this.gameObject.SetActive(false);
                break;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
