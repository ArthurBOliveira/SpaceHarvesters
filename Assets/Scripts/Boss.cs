using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public Sprite[] BossSprite;	
	public float speed;
	public float limitX;

	public GameObject shot;
	public GameObject shorterShot;
	public Transform ShotSpawnLeft;
	public Transform ShotSpawnRight;
	public Transform ShotSpawnCentral;
	public float fireRate;

	public GameObject enemy;
	public GameObject enemyReverse;

	public float phaseWait;

	private float nextFire;

	private GameController gameController;

	private float z = 6;

	// Use this for initialization
	void Start () {

		int spriteRandomizer = Random.Range (0,3);

		this.gameObject.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = BossSprite [spriteRandomizer];

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		int aux = gameControllerObject.GetComponent<GameController> ().currentRound / 10;

		//shield = shield * aux;

		MoveDown ();

		StartCoroutine (ShootStraightLaser ());
			
	}

	void Update() {		

		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, -1.5f, 1.5f),
			0,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, 4.2f, 1000)
		);

		if (z > 4.2f)
			z = z - 0.01f;

		Vector3 v = new Vector3(0,0, z);
		v.x += limitX * Mathf.Sin (Time.time * speed);
		transform.position = v;
	}

	IEnumerator ShootStraightLaser(){
		int count = 0;

		yield return new WaitForSeconds (phaseWait);

		while (true) {
			if (count < 18) {
				nextFire = Time.time + fireRate;

				Instantiate (shot, ShotSpawnLeft.position, ShotSpawnLeft.rotation);
				Instantiate (shot, ShotSpawnRight.position, ShotSpawnRight.rotation);
				Instantiate (shorterShot, ShotSpawnCentral.position, ShotSpawnCentral.rotation);

				GetComponent<AudioSource > ().Play ();

				count++;
				yield return new WaitForSeconds (0.2f);
			} else {
				yield return new WaitForSeconds (1);

				Vector3 spawnPosition;
				Quaternion spawRotation;

				//Normais
				spawnPosition = new Vector3 (0, 0, 6);
				spawRotation = Quaternion.identity;

				Instantiate (enemy, spawnPosition, spawRotation);

				spawnPosition = new Vector3 (-1.75f, 0, 6);
				spawRotation = Quaternion.identity;

				Instantiate (enemy, spawnPosition, spawRotation);

				spawnPosition = new Vector3 (1.75f, 0, 6);
				spawRotation = Quaternion.identity;

				Instantiate (enemy, spawnPosition, spawRotation);

				yield return new WaitForSeconds (1);

				//Reversos
				spawnPosition = new Vector3 (-0.8f, 0, -1);
				spawRotation = Quaternion.identity;

				Instantiate (enemyReverse, spawnPosition, spawRotation);

				spawnPosition = new Vector3 (0.8f, 0, -1);
				spawRotation = Quaternion.identity;

				Instantiate (enemyReverse, spawnPosition, spawRotation);

				count = 0;
				yield return new WaitForSeconds (2);
			}
		}
	}

	/*void OnTriggerEnter(Collider other) {
		if (other.tag == "PlayerBolt") {
			Instantiate (explosionHit, transform.position, transform.rotation);

			CauseDamage (damageTaken);
			Destroy(other.gameObject);
		}
	}

	void CauseDamage(int damage) {
		shield -= damage;
		//healthBarSlider.value -= damage;

		if (shield <= 0) {
			Instantiate (explosionDestruction, transform.position, transform.rotation);
			Destroy(gameObject);
			gameController.AddScore (scoreValue);
		}
	}*/

	void MoveDown(){
		GetComponent<Rigidbody> ().velocity = Vector3.back * speed;
	}
}