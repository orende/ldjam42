using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterSoundPlayed : MonoBehaviour {
    private AudioSource audioSource;
    //
    // Use this for initialization
    void Start () {
        audioSource = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!audioSource.isPlaying)
        {
            Destroy(this.gameObject, 0.5f);
        }
	}
}
