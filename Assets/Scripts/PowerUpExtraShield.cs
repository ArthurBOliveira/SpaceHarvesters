using UnityEngine;
using System.Collections;

public class PowerUpExtraShield : MonoBehaviour {
	
	private Player player;

	void Start(){
		GameObject playerObject = GameObject.FindWithTag ("Player");

		if (playerObject != null) {
			player = playerObject.GetComponent<Player> ();
		} 
		if (playerObject == null) {
			Debug.Log ("Cannot find 'playerObject script'");			
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player") {
			GetComponent<AudioSource > ().Play ();
			Destroy(gameObject);
			player.ExtraShield ();
		} 
	}
}
