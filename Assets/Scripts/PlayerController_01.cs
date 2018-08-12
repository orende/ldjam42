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
    public GameObject hitBox;
    public int wallResources;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Schmooze"))
        {
            speed -= 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Schmooze"))
        {
            speed += 1;
        }
    }

    // THese are the events that will occur  when the player uses an item
    void MopAction()
    {
        Debug.Log("USING MOP");
        hitBox.SetActive(true);

    }

    void AxeAction()
    {
        Debug.Log("USING AXE");

        hitBox.SetActive(true);
    }

    void WallBuildAction()
    {
        if (wallResources > 0)
        {
            Debug.Log("BUILDING A WALL");
            Instantiate(wall, transform.position + transform.forward * 2, transform.rotation);
            wallResources--;
        }
        else
        {
            Debug.Log("NOT ENOUGH RESOURCES TO BUILD WALL");
        }
    }

    void Update()
    {

        CharacterController controller = GetComponent<CharacterController>();

        float hSpeed =  speed * Input.GetAxis("Horizontal");
        float vSpeed = speed * Input.GetAxis("Vertical");
        Vector3 movment = new Vector3(hSpeed, 0, vSpeed);
        controller.SimpleMove(movment);

        transform.rotation = Quaternion.LookRotation(movment);

        if (Input.GetButtonDown("Fire1"))
        {
                if (equippedItem == 1) { AxeAction(); }
                else if (equippedItem == 2) { MopAction(); }
                else if (equippedItem == 3) { WallBuildAction(); }
                else if (equippedItem == 0) { Debug.Log("NO ITEM EQUIPPED"); }
                else { Debug.Log("ERROR NO SUCH ITEM NAME WAS FOUND IN REGISTRY"); }
        }

            if (Input.GetButtonDown("Fire2"))
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
                    hitBox.SetActive(true);
                }

            }
    }

}
