using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController_Script : MonoBehaviour {

    public float gameTimer;
    public int winCount;
    public Text text;

	// Use this for initialization
	void Start () {
        gameTimer = 60;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Escape)) { Application.Quit(); }
        if (Input.GetKey(KeyCode.Space)) { Application.LoadLevel(1); }

        gameTimer -= 1 * Time.deltaTime;

        if (gameTimer <= 0)
        {
            
        }

    }
}
