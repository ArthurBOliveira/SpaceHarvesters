using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {

	public GameObject shot;
	public Transform ShotSpawnEnemy1;
	public float fireRate;

	private float nextFire;
	private Player player;
	private GameController gameController;

	public Sprite[] EnemySprite;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		GameObject playerObject = GameObject.FindWithTag ("Player");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
			player = playerObject.GetComponent<Player> ();
		} 
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController script'");			
		}

		int spriteRandomizer = Random.Range (0,19);

		this.gameObject.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = EnemySprite [spriteRandomizer];
	}
	
	// Update is called once per frame
	void Update () {
		if( Time.time > nextFire){
			nextFire = Time.time + fireRate;

			Instantiate(shot, ShotSpawnEnemy1.position, ShotSpawnEnemy1.rotation);

			GetComponent<AudioSource > ().Play ();
		}
	}
}
