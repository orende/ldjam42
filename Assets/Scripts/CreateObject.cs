using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour {

    public GameObject objectToCreate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Create()
    {
        GameObject.Instantiate(objectToCreate,this.gameObject.transform.position,new Quaternion(0,0,0,0));
    }
}
