using UnityEngine;
using System.Collections;

public class PowerUpBlaster : MonoBehaviour {

	private Player player;

	void Start () {
		GameObject playerObject = GameObject.FindWithTag ("Player");

		player = playerObject.GetComponent<Player> ();
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player") {

			player.Blast ();
			Destroy(gameObject);

		} 
	}
}
