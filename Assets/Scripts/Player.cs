using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Player : MonoBehaviour
{

    public Boundary boundary;
    public float tilt;
    public float speed;
    public int shield;
    public int maxShield;

    public GameObject shot;
    public GameObject shot2;
    public GameObject shot3;
    public GameObject shot4;
    public GameObject shot5;

    public Transform ShotSpawnMiddle;
    public Transform ShotSpawnLeft;
    public Transform ShotSpawnRight;
    public Transform ShotSpawnFarLeft;
    public Transform ShotSpawnFarRight;
    public float fireRate;

    public Slider healthBarSlider;
    public Image Fill;

    public GameObject explosion;

    private GameController gameController;
    private float nextFire;
    private Save save;

    void Start()
    {
        save = new Save();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController script'");
        }

        SetUpShield();
        SetUpBolt();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Shoot();

            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {

        //Keyboard
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        //GetComponent<Rigidbody>().velocity = movement * speed;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Shoot();
        //}

        //Mouse
        //float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = Input.GetAxis("Mouse Y");

        //GetComponent<Transform>().position += Vector3.right * mouseX * speed;
        //GetComponent<Transform>().position += Vector3.forward * mouseY * speed;

        //Touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            transform.Translate(touchDeltaPosition.x * speed, 0, touchDeltaPosition.y * speed);
        }

        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        //GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0, 0, GetComponent<Rigidbody> ().velocity.x * -tilt);
    }

    public void CauseDamage(int damage)
    {

        shield -= damage;
        healthBarSlider.value -= damage;

        //Handheld.Vibrate();

        if (shield <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameObject.SetActive(false);
            gameController.GameOver();
        }
    }

    public void Heal(int heal)
    {

        shield += heal;
        healthBarSlider.value += heal;

        if (shield > maxShield)
        {
            shield = maxShield;
        }
    }

    public void ExtraShield()
    {
        GameObject extraShieldObject = GameObject.Find("ExtraShield");

        extraShieldObject.SetActive(true);

        StartCoroutine(resetExtraShield());
    }

    public void Blast()
    {
        fireRate = 0.08f;
        StartCoroutine(resetFireRate());
    }

    IEnumerator resetExtraShield()
    {
        GameObject extraShieldObject = GameObject.Find("ExtraShield");

        yield return new WaitForSeconds(5f);

        extraShieldObject.SetActive(false);
    }

    IEnumerator resetFireRate()
    {
        yield return new WaitForSeconds(5f);

        fireRate = 0.25f;
    }

    void SetUpShield()
    {

        switch (save.ShieldLevel())
        {
            case 0:           
                shield = 100;
                maxShield = 100;
                healthBarSlider.maxValue = 100;
                healthBarSlider.value = 100;
                Fill.color = new Color(0, 218, 55);
                break;
            case 1:
                shield = 125;
                maxShield = 125;
                healthBarSlider.maxValue = 125;
                healthBarSlider.value = 125;
                Fill.color = new Color(0, 0, 255);
                break;
            case 2:
                shield = 150;
                maxShield = 150;
                healthBarSlider.maxValue = 150;
                healthBarSlider.value = 150;
                Fill.color = new Color(255, 200, 0);
                break;

            case 3:
                shield = 175;
                maxShield = 175;
                healthBarSlider.maxValue = 175;
                healthBarSlider.value = 175;
                Fill.color = new Color(188, 0, 255);
                break;

            case 4:
                shield = 200;
                maxShield = 200;
                healthBarSlider.maxValue = 200;
                healthBarSlider.value = 200;
                Fill.color = new Color(0, 255, 255);
                break;

            case 5:
                shield = 250;
                maxShield = 250;
                healthBarSlider.maxValue = 250;
                healthBarSlider.value = 250;
                Fill.color = new Color(255, 0, 0);
                break;
            default:
                shield = 100;
                maxShield = 100;
                healthBarSlider.maxValue = 100;
                healthBarSlider.value = 100;
                Fill.color = new Color(0, 218, 55);
                break;
        }
    }

    void Shoot()
    {
        switch (save.WeaponsLevel())
        {
            case 0:
                Instantiate(shot, ShotSpawnMiddle.position, ShotSpawnMiddle.rotation);
                break;
            case 1:
                Instantiate(shot, ShotSpawnMiddle.position, ShotSpawnMiddle.rotation);
                Instantiate(shot, ShotSpawnLeft.position, ShotSpawnLeft.rotation);
                break;
            case 2:
                Instantiate(shot, ShotSpawnMiddle.position, ShotSpawnMiddle.rotation);
                Instantiate(shot, ShotSpawnLeft.position, ShotSpawnLeft.rotation);
                Instantiate(shot, ShotSpawnRight.position, ShotSpawnRight.rotation);
                break;
            case 3:
                Instantiate(shot, ShotSpawnMiddle.position, ShotSpawnMiddle.rotation);
                Instantiate(shot, ShotSpawnLeft.position, ShotSpawnLeft.rotation);
                Instantiate(shot, ShotSpawnRight.position, ShotSpawnRight.rotation);
                Instantiate(shot, ShotSpawnFarLeft.position, ShotSpawnFarLeft.rotation);
                break;
            case 4:
                Instantiate(shot, ShotSpawnMiddle.position, ShotSpawnMiddle.rotation);
                Instantiate(shot, ShotSpawnLeft.position, ShotSpawnLeft.rotation);
                Instantiate(shot, ShotSpawnRight.position, ShotSpawnRight.rotation);
                Instantiate(shot, ShotSpawnFarLeft.position, ShotSpawnFarLeft.rotation);
                Instantiate(shot, ShotSpawnFarRight.position, ShotSpawnFarRight.rotation);
                break;
            default:
                Instantiate(shot, ShotSpawnMiddle.position, ShotSpawnMiddle.rotation);
                Instantiate(shot, ShotSpawnLeft.position, ShotSpawnLeft.rotation);
                Instantiate(shot, ShotSpawnRight.position, ShotSpawnRight.rotation);
                Instantiate(shot, ShotSpawnFarLeft.position, ShotSpawnFarLeft.rotation);
                Instantiate(shot, ShotSpawnFarRight.position, ShotSpawnFarRight.rotation);
                break;
        }
    }

    void SetUpBolt()
    {
        int blastLevel = save.BoltLevel();

        switch (blastLevel)
        {
            case 0:
                Instantiate(shot, ShotSpawnMiddle.position, ShotSpawnMiddle.rotation);
                break;
            case 1:
                shot = shot2;
                break;
            case 2:
                shot = shot3;
                break;
            case 3:
                shot = shot4;
                break;
            case 4:
                shot = shot5;
                break;
            default:
                shot = shot5;
                break;
        }
    }

    public void IncreaseSpeed()
    {
        speed = speed + 0.01f;
    }
}
