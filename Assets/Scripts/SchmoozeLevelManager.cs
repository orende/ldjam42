using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchmoozeLevelManager : MonoBehaviour {

	public Slider meter;
	public int increaseInterval = 2;
	public float spawnerCost = 0.2f;
	public float nonSpawnerCost = 0.1f;

	void Start () {
		StartCoroutine(IncreaseSchmoozeLevel());
	}
	
	void Update () {
		
	}

	public float getLevel() {
		return meter.value;
	}

	IEnumerator IncreaseSchmoozeLevel() {
		while (true) {
			yield return new WaitForSeconds(increaseInterval);
			meter.value += 0.05f;
		}
	}

	public bool canAffordNonSpawner() {
		return meter.value - nonSpawnerCost > 0f;
	}

	public bool canAffordSpawner() {
		return meter.value - spawnerCost > 0f;
	}

	public void buyNonSpawner() {
		meter.value -= nonSpawnerCost;
	}

	public void buySpawner() {
		meter.value -= spawnerCost;
	}
}
