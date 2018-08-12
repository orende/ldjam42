using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Trigger_PlayerController : MonoBehaviour {

    public Text itemText;
    public Text wallText;

    void Start() {
        
    }

    void Update () {
        
    }

    void FixedUpdate()
    {
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other);

        if (other.gameObject.CompareTag("Player")) {}

        if (other.gameObject.CompareTag("Schmooze") || other.gameObject.CompareTag("Spawner"))
        {
            if (this.GetComponentInParent<PlayerController_01>().equippedItem == 2) {
                other.gameObject.GetComponent<Health>().DecreaseHP();
            }
        }

        if (other.gameObject.CompareTag("Destructable"))
        {
             if (this.GetComponentInParent<PlayerController_01>().equippedItem == 1)
            {
                this.GetComponentInParent<PlayerController_01>().wallResources++;
                wallText.text = "" + this.GetComponentInParent<PlayerController_01>().wallResources + " Walls";
                other.gameObject.GetComponent<Health>().DecreaseHP();
            }
        }

        if (other.gameObject.CompareTag("Equipment"))
        {
            if (this.GetComponentInParent<PlayerController_01>().equippedItem == 0){ 
                if (other.gameObject.name == "Axe" || other.gameObject.name == "Axe(Clone)") { 
                    this.GetComponentInParent<PlayerController_01>().equippedItem = 1; 
                    itemText.text = "Axe";
                    Destroy(other.gameObject); 
                } else if (other.gameObject.name == "Mop" || other.gameObject.name == "Mop(Clone)") { 
                    this.GetComponentInParent<PlayerController_01>().equippedItem = 2; 
                    itemText.text = "Mop";
                    Destroy(other.gameObject); 
                } else if (other.gameObject.name == "WallBuilder" || other.gameObject.name == "WallBuilder(Clone)") { 
                    this.GetComponentInParent<PlayerController_01>().equippedItem = 3; 
                    itemText.text = "WallBuilder";
                    Destroy(other.gameObject); 
                }
            }
        }

        else { Debug.Log("No object for collider"); }

        this.gameObject.SetActive(false);

    }
}
