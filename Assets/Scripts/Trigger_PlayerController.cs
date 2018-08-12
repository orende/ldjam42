using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_PlayerController : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other);

        if (other.gameObject.CompareTag("Player")) {}

        if (other.gameObject.CompareTag("Schmooze") || other.gameObject.CompareTag("Spawner"))
        {
            if (this.GetComponentInParent<PlayerController_01>().equippedItem == 2) { Destroy(other.gameObject); }
        }

        if (other.gameObject.CompareTag("Destructable"))
        {
             if (this.GetComponentInParent<PlayerController_01>().equippedItem == 1)
            {
                this.GetComponentInParent<PlayerController_01>().wallResources++;
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("Equipment"))
        {
            if (this.GetComponentInParent<PlayerController_01>().equippedItem == 0){ 
                if (other.gameObject.name == "Axe" || other.gameObject.name == "Axe(Clone)") { this.GetComponentInParent<PlayerController_01>().equippedItem = 1; Destroy(other.gameObject); }
                else if (other.gameObject.name == "Mop" || other.gameObject.name == "Mop(Clone)") { this.GetComponentInParent<PlayerController_01>().equippedItem = 2; Destroy(other.gameObject); }
                else if (other.gameObject.name == "WallBuilder" || other.gameObject.name == "WallBuilder(Clone)") { this.GetComponentInParent<PlayerController_01>().equippedItem = 3; Destroy(other.gameObject); }
            }
        }

        else { Debug.Log("No object for collider"); }

        this.gameObject.SetActive(false);

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
    }
}
