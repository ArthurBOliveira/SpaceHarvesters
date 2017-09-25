using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public int shield;
	public int scoreValue;
	public int damageByImpact;

	public GameObject explosionDestruction;
	public GameObject explosionHit;

	void Start () {

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		int aux = gameControllerObject.GetComponent<GameController> ().currentRound / 10;

		aux = aux == 0 ? 1 : aux;

		shield = shield * aux;
		scoreValue = scoreValue * aux;
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {			
			Instantiate (explosionHit, transform.position, transform.rotation);

			other.GetComponent<Player> ().CauseDamage (damageByImpact);
			CauseDamage (damageByImpact);
		} else if (other.tag == "PlayerBolt") {
			Instantiate (explosionHit, transform.position, transform.rotation);

			int damageTaken = other.GetComponent<Damage> ().damage;

			CauseDamage (damageTaken);
			Destroy(other.gameObject);
		}
	}

	void CauseDamage(int damage) {
		shield -= damage;

		if (shield <= 0) {
			GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

			Instantiate (explosionDestruction, transform.position, transform.rotation);
			Destroy(gameObject);
			gameControllerObject.GetComponent<GameController> ().AddScore (scoreValue);
		}
	}
}
