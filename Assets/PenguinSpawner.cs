using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinSpawner : MonoBehaviour {
	public GameObject penguin;
	public float xRange;
	public float zRange;

	private static PenguinSpawner Instance;
	private Vector3 spawnLocation;

	void Awake() {
		if (Instance == null)
			Instance = this;

		spawnLocation = gameObject.transform.position;
	}

	// Use this for initialization
	void Start () {
		int initialPenguins = Random.Range (4, 11);
		for (int i = 0; i < initialPenguins; i++)
			Spawn ();

		StartCoroutine (SpawnCycle ());
	}

	private IEnumerator SpawnCycle() {
		yield return new WaitForSeconds (1f);

		while (true) {
			Spawn ();
			yield return new WaitForSeconds (3f);
		}
	}

	private void Spawn() {
		Vector3 spawnPosition = GetSpawnPosition ();
		Instantiate (penguin, spawnPosition, transform.rotation);
	}

	private Vector3 GetSpawnPosition() {
		spawnLocation.x = gameObject.transform.position.x + Random.Range (-xRange, xRange);
		spawnLocation.z = gameObject.transform.position.z + Random.Range (-zRange, zRange);

		return spawnLocation;
	}
}
