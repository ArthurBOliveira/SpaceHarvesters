using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GUIText highScoreMenu;
    public GUIText CoinsMenu;
    private Save save;
    private FBLayer FB;

    // Use this for initialization
    void Start()
    {
        save = new Save();
        FB = new FBLayer();

        highScoreMenu.text = "High Score: " + save.HighScore();
        CoinsMenu.text = "Coins: " + save.TotalCoins();

        //FB.FBLogin();
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void LoadScore()
    {
        SceneManager.LoadScene("Highscores");
    }
}
