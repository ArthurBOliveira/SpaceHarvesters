using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;

	public float interval = 3.0f;
	private float timestamp = .0f;

	// Use this for initialization
	void Start() 
	{
		GetComponent<Rigidbody> ().velocity = Vector3.forward * speed;

		//GetComponent<Transform>().position += Vector3.forward * speed;

		timestamp = Time.time;  // save the timestamp when the bullet instantiated
	}

	void Update()
	{
		if(interval < Time.time - timestamp)
		{
			Destroy(gameObject);  // destroy the bullet after {interval} seconds
		}
	}

    public void IncreaseSpeed()
    {
        speed = speed * 1.2f;
    }
}
