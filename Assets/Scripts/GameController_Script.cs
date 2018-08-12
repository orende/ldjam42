using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController_Script : MonoBehaviour {

    public float gameTimer;
    public int winCount;
    public Text text;

    void GameFinished() {

        if (getSchmoozeLevel() >= winCount) { text.text = "THE SCHMOOZE WINS"; }
        else { text.text = "THE MAD SCIENTIST WINS"; }
    }

    private int getSchmoozeLevel()
    {
        int result = 0;
        GameObject[] arr = GameObject.FindGameObjectsWithTag("Schmooze");
        foreach (GameObject obj in arr)
        {
            if (obj.activeSelf)
            {
                result++;
            }
        }
        return result;
    }

    // Use this for initialization
    void Start () {
        if (gameTimer <= 0) { gameTimer = 60; }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Escape)) { Application.Quit(); }
        if (Input.GetKey(KeyCode.Space)) { Application.LoadLevel(1); }

        gameTimer -= 1 * Time.deltaTime;

        if (gameTimer <= 0)
        {
            GameFinished();
        }

    }
}
