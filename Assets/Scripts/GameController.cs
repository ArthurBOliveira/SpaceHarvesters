using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject enemy;
    public GameObject powerUp;
    public GameObject boss;
    public GameObject barrier;
    public GameObject enemyBolt;

    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText highScoreText;
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText roundText;
    public GUIText coinsEarnedText;

    public InputField InputName;

    public Button restartGameButton;
    public Button endGameButton;
    public Button btnSaveScore;
    public int currentRound = 1;

    private int score;
    private Save save;
    private bool newRecord = false;

    private float hazardSpeed;
    private float enemySpeed;
    private float barrierSpeed;
    private float enemyBoltSpeed;

    private GameObject player;

    void Start()
    {

        save = new Save();

        restartText.text = "";
        gameOverText.text = "";

        StartCoroutine(SpawnWaves());
        score = 0;
        UpdateScore();
        highScoreText.text = "High Score: " + save.HighScore();

        restartGameButton.gameObject.SetActive(false);
        endGameButton.gameObject.SetActive(false);
        btnSaveScore.gameObject.SetActive(false);
        InputName.gameObject.SetActive(false);

        player = GameObject.Find("Player");

        hazardSpeed = hazard.GetComponent<Mover>().speed;
        enemySpeed = enemy.GetComponent<Mover>().speed;
        barrierSpeed = barrier.GetComponent<Mover>().speed;
        enemyBoltSpeed = enemyBolt.GetComponent<Mover>().speed;
    }

    IEnumerator SpawnWaves()
    {
        Vector3 spawnPosition;
        Quaternion spawRotation;

        int hazardRound = 10;

        yield return new WaitForSeconds(spawnWait);

        while (true)
        {
            roundText.text = "Round: " + currentRound;

            //player.GetComponent<Player> ().IncreaseSpeed ();


            if (currentRound % 10 == 0)
            {
                //Spawn Boss
                spawnPosition = new Vector3(0, 0, spawnValue.z);
                spawRotation = Quaternion.identity;

                Instantiate(boss, spawnPosition, spawRotation);
                yield return new WaitUntil(() => GameObject.FindWithTag("Boss") == null);
                gameOverText.text = "Boss Defeated";
                yield return new WaitForSeconds(1);
                gameOverText.text = "Increasing Difficulty";
                yield return new WaitForSeconds(1);
                gameOverText.text = "";

                //IncreaseSpeed();
            }
            else
            {
                string gambi = currentRound.ToString();
                gambi = gambi[gambi.Length - 1].ToString();


                if (int.Parse(gambi) == 1)
                {
                    //Spawn Hazards
                    for (int i = 0; i < hazardCount; i++)
                    {
                        spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), 0, spawnValue.z);
                        spawRotation = Quaternion.identity;

                        Instantiate(hazard, spawnPosition, spawRotation);
                        yield return new WaitForSeconds(spawnWait);
                    }
                    hazardRound += 10;
                }
                else if (currentRound % 5 != 0)
                {
                    //Spawn Enemys
                    int aux = (int)(currentRound * 1.5f);
                    for (int i = 0; i < aux; i++)
                    {
                        spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), 0, spawnValue.z);
                        spawRotation = Quaternion.identity;

                        Instantiate(enemy, spawnPosition, spawRotation);
                        yield return new WaitForSeconds(spawnWait);
                    }
                    yield return new WaitForSeconds(0.5f);
                }
                else
                {
                    //Spawn Barrier
                    spawRotation = Quaternion.identity;

                    yield return new WaitForSeconds(0.5f);

                    //Easy
                    float x1 = 1.45f, x2 = -1.45f;

                    for (int i = 0; i <= 6; i++)
                    {

                        spawnPosition = new Vector3(x1, 0, spawnValue.z);
                        Instantiate(barrier, spawnPosition, spawRotation);

                        spawnPosition = new Vector3(x2, 0, spawnValue.z);
                        Instantiate(barrier, spawnPosition, spawRotation);

                        x1 += 0.25f; x2 += 0.25f;

                        yield return new WaitForSeconds(0.2f);
                    }

                    for (int i = 0; i <= 6; i++)
                    {

                        spawnPosition = new Vector3(x1, 0, spawnValue.z);
                        Instantiate(barrier, spawnPosition, spawRotation);

                        spawnPosition = new Vector3(x2, 0, spawnValue.z);
                        Instantiate(barrier, spawnPosition, spawRotation);

                        x1 -= 0.25f; x2 -= 0.25f;

                        yield return new WaitForSeconds(0.2f);
                    }

                    yield return new WaitForSeconds(0.5f);

                    x1 = -1.45f; x2 = 1.45f;

                    for (int i = 0; i <= 6; i++)
                    {

                        spawnPosition = new Vector3(x1, 0, spawnValue.z);
                        Instantiate(barrier, spawnPosition, spawRotation);

                        spawnPosition = new Vector3(x2, 0, spawnValue.z);
                        Instantiate(barrier, spawnPosition, spawRotation);

                        x1 -= 0.25f; x2 -= 0.25f;

                        yield return new WaitForSeconds(0.2f);
                    }

                    for (int i = 0; i <= 6; i++)
                    {

                        spawnPosition = new Vector3(x1, 0, spawnValue.z);
                        Instantiate(barrier, spawnPosition, spawRotation);

                        spawnPosition = new Vector3(x2, 0, spawnValue.z);
                        Instantiate(barrier, spawnPosition, spawRotation);

                        x1 += 0.25f; x2 += 0.25f;

                        yield return new WaitForSeconds(0.2f);
                    }

                    //Medium

                    for (int i = 0; i < 5; i++)
                    {
                        spawnPosition = new Vector3(0.8f, 0, spawnValue.z);
                        Instantiate(barrier, spawnPosition, spawRotation);

                        yield return new WaitForSeconds(0.4f);

                        spawnPosition = new Vector3(-0.8f, 0, spawnValue.z);
                        Instantiate(barrier, spawnPosition, spawRotation);


                        yield return new WaitForSeconds(0.4f);

                    }


                    //Hard
                    for (int i = 0; i < 5; i++)
                    {
                        spawnPosition = new Vector3(1.5f, 0, spawnValue.z);
                        Instantiate(barrier, spawnPosition, spawRotation);

                        spawnPosition = new Vector3(-1.5f, 0, spawnValue.z);
                        Instantiate(barrier, spawnPosition, spawRotation);

                        yield return new WaitForSeconds(0.4f);

                        spawnPosition = new Vector3(0, 0, spawnValue.z);
                        Instantiate(barrier, spawnPosition, spawRotation);


                        yield return new WaitForSeconds(0.4f);

                    }
                }

                //Spawn PowerUp
                if (currentRound % 5 == 0 && currentRound != 0)
                {
                    spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), 0, spawnValue.z);
                    spawRotation = Quaternion.identity;

                    Instantiate(powerUp, spawnPosition, spawRotation);
                }
            }

            currentRound++;
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        StopCoroutine(SpawnWaves());

        newRecord = save.SaveScore(score);

        if (newRecord)
        {
            gameOverText.text = "New Record";

            btnSaveScore.gameObject.SetActive(true);
            InputName.gameObject.SetActive(true);
        }
        else
            gameOverText.text = "Game Over";

        int aux = (int)(score * 0.1f);

        coinsEarnedText.text = "Coins: " + aux;

        int coins = save.TotalCoins() + aux;

        save.SaveCoins(coins);

        restartGameButton.gameObject.SetActive(true);
        endGameButton.gameObject.SetActive(true);

        //ResetSpeed();
    }

    void UpdateScore()
    {
        scoreText.text = "Current Score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("First");
    }

    void IncreaseSpeed()
    {
        hazard.GetComponent<Mover>().IncreaseSpeed();
        enemy.GetComponent<Mover>().IncreaseSpeed();
        barrier.GetComponent<Mover>().IncreaseSpeed();
        enemyBolt.GetComponent<Mover>().IncreaseSpeed();
    }

    void ResetSpeed()
    {
        hazard.GetComponent<Mover>().speed = hazardSpeed;
        enemy.GetComponent<Mover>().speed = enemySpeed;
        barrier.GetComponent<Mover>().speed = barrierSpeed;
        enemyBolt.GetComponent<Mover>().speed = enemyBoltSpeed;
    }

    public void SaveScore()
    {
        string name = InputName.text.Replace("\"", "");

        name = name.Length > 15 ? name.Substring(0, 15) : name;

        HighScore newScore = new HighScore()
        {
            Player = name,
            Score = score
        };

        StartCoroutine(WaitForRequest(HighscoreAPI.SaveScore(newScore)));

        btnSaveScore.gameObject.SetActive(false);
        InputName.gameObject.SetActive(false);
    }

    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            Debug.Log(www.text);
        }
        else
        {
            Debug.Log(www.error);
        }
    }
}