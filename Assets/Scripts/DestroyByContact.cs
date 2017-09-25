using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	private GameController gameController;
	private Player player;

	public Sprite[] AsteroidSprite;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		GameObject playerObject = GameObject.FindWithTag ("Player");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
			player = playerObject.GetComponent<Player> ();
		} 
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController script'");			
		}

		int spriteRandomizer = Random.Range (0,7);

		this.gameObject.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = AsteroidSprite [spriteRandomizer];
	}
}
