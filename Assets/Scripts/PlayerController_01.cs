using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController_01 : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public int equippedItem = 0;
    public GameObject wall;
    public GameObject wallItem;
    public GameObject mopItem;
    public GameObject axeItem;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        
        switch (equippedItem)
        {
            case 1:
                if (other.gameObject.CompareTag("Destructable")){ Destroy(other.gameObject); }
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
            case 2:
                if (other.gameObject.CompareTag("Schmooze")) { Destroy(other.gameObject); }
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
            case 0:
                if (other.gameObject.CompareTag("Equipment"))
                {
                    if (other.gameObject.name == "Axe" || other.gameObject.name == "Axe(Clone)") { equippedItem = 1; }
                    else if (other.gameObject.name == "Mop" || other.gameObject.name == "Mop(Clone)") { equippedItem = 2; }
                    else if (other.gameObject.name == "WallBuilder" || other.gameObject.name == "WallBuilder(Clone)") { equippedItem = 3; }

                    Destroy(other.gameObject);
                }
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
            default:
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
        }
    }

    // THese are the events that will occur  when the player uses an item
    void MopAction()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    void AxeAction()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    void WallBuildAction()
    {
        Debug.Log("BUILDING A WALL");
        Instantiate(wall, new Vector3(transform.position.x, transform.position.y, transform.position.z) + new Vector3(0,0,2), transform.rotation);
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        /*
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
        */

        float hSpeed =  speed * Input.GetAxis("Horizontal");
       float vSpeed = speed * Input.GetAxis("Vertical");
        Vector3 movment = new Vector3(hSpeed, 0, vSpeed);
        controller.SimpleMove(movment);

        if (Input.GetButton("Fire1"))
        {
                if (equippedItem == 1) { AxeAction(); }
                else if (equippedItem == 2) { MopAction(); }
                else if (equippedItem == 3) { WallBuildAction(); }
                else if (equippedItem == 0) { Debug.Log("NO ITEM EQUIPPED"); }
                else { Debug.Log("ERROR NO SUCH ITEM NAME WAS FOUND IN REGISTRY"); }
        }

        if (Input.GetButton("Fire2"))
        {
            if (equippedItem == 2)
            {
                Instantiate(mopItem, transform.position, transform.rotation);
                equippedItem = 0;
            }
            else if (equippedItem == 1)
            {
                Instantiate(axeItem, transform.position, transform.rotation);
                equippedItem = 0;
            }

            else if (equippedItem == 3)
            {
                Instantiate(wallItem, transform.position, transform.rotation);
                equippedItem = 0;
            }

            else
            {
                this.gameObject.GetComponent<BoxCollider>().gameObject.SetActive(true);
            }

        }

    }
}
