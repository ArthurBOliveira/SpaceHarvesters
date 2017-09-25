using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreMenu : MonoBehaviour
{

    public GUIText highScoreNumber;
    public GUIText FaceId;

    private Save save;
    private FBLayer FB;
    void Start()
    {
        save = new Save();
        FB = new FBLayer();

        highScoreNumber.text = save.HighScore().ToString();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("First");
    }

    public void LoginFacebook()
    {
        string idFace = FB.FBLogin();

        FaceId.text = idFace;
    }

    public void ShareFacebook()
    {
        FB.FBShare();
    }
}
