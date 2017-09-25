using UnityEngine;
using System.Collections;

public class PowerUpShield : MonoBehaviour {
	
	public int heal;

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
			player.Heal (heal);
			Destroy(gameObject);
		} 
	}
}
