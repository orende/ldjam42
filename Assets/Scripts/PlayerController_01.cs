﻿using UnityEngine;
using UnityEngine.UI;
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
    private float actionTimer;
    public float actionDelay;
    public Text itemText;
    public Text wallText;
    private bool disableAction = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Schmooze"))
        {
            if (speed - 1 >= 1) {
                speed -= 1;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Schmooze"))
        {
            if (speed + 1 <= 3) {
                speed += 1;
            }
        }
    }

    // THese are the events that will occur  when the player uses an item
    void MopAction()
    {
        Debug.Log("USING MOP");
        disableAction = true;
        actionTimer = actionDelay;
    }

    void AxeAction()
    {
        Debug.Log("USING AXE");
        disableAction = true;
        actionTimer = actionDelay;
    }

    void WallBuildAction()
    {
        if (wallResources > 0)
        {
            Debug.Log("BUILDING A WALL");
            //Instantiate(wall, transform.position + transform.forward * 2, transform.rotation);
            wallResources--;
            wallText.text = "" + wallResources + " Walls";
            disableAction = true;
            actionTimer = actionDelay;
        }
        else
        {
            Debug.Log("NOT ENOUGH RESOURCES TO BUILD WALL");
        }
    }

    void Update()
    {
        if (disableAction)
        {
            if (actionTimer > 0) { actionTimer -= 1 * Time.deltaTime; return; }
            else
            {
                disableAction = false;
                if (equippedItem == 1) { hitBox.SetActive(true); }
                else if (equippedItem == 2) { hitBox.SetActive(true); }
                else if (equippedItem == 3)
                {
                    Instantiate(wall, transform.position + transform.forward * 2, transform.rotation);
                }
            }
        }
        

        CharacterController controller = GetComponent<CharacterController>();

        float hSpeed =  speed * Input.GetAxis("Horizontal");
        float vSpeed = speed * Input.GetAxis("Vertical");
        Vector3 movment = new Vector3(hSpeed, 0, vSpeed);
        controller.SimpleMove(movment);
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0){ }
        else
        {
            transform.rotation = Quaternion.LookRotation(movment);
        }

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
                    itemText.text = "No item";
                }
                else if (equippedItem == 1)
                {
                    Instantiate(axeItem, transform.position, transform.rotation);
                    equippedItem = 0;
                    itemText.text = "No item";
                }

                else if (equippedItem == 3)
                {
                    Instantiate(wallItem, transform.position, transform.rotation);
                    equippedItem = 0;
                    itemText.text = "No item";
                }

                else
                {
                    hitBox.SetActive(true);
                }

            }
    }

}
