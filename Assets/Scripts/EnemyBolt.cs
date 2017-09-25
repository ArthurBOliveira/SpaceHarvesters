using UnityEngine;
using System.Collections;

public class EnemyBolt : MonoBehaviour
{
    public int damage;

    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController script'");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
            //gameController.GameOver ();

            other.GetComponent<Player>().CauseDamage(damage);
            Destroy(gameObject);
        }
    }
}
