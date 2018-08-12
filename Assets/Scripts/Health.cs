using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {

    public int health;
    public UnityEvent onHealthDecreaseEvent;
    public UnityEvent deathEvent;

	// Use this for initialization
	void Start () {
        //deathEvent = new UnityEvent();
	}
	
	// Update is called once per frame
	void Update () {
        if (health < 1)
        {
            DecreaseHP();
        }
	}

    public void DecreaseHP( int i)
    {
        health = health - i;
        if(health<=0)
        {
            deathEvent.Invoke();
            Debug.Log("deathEvent invoked.");
            Object.Destroy(this.gameObject);
        }
        else
        {
            onHealthDecreaseEvent.Invoke();
        }
    }

    public void DecreaseHP()
    {
        DecreaseHP(1);
    }
    
}
