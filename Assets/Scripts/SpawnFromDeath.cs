using UnityEngine;
using System.Collections;

public class SpawnFromDeath : MonoBehaviour {

	public GameObject objectToSpawn;
	public int rate;

	void OnDisable() {
		float RnG = Random.Range(0f, 100f);

		if (Random.Range (0, 100) <= rate) {

			Instantiate (objectToSpawn, transform.position, transform.rotation);
		}
	}
}