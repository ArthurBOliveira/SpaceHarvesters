using UnityEngine;
using System.Collections;

public class ExtraShield : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag != "Player" && other.tag != "PlayerBolt" &&  other.tag != "PowerUp") {
			//Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			//gameController.GameOver ();

			Destroy(other.gameObject);
			gameObject.SetActive (false);
		} 
	}
}
