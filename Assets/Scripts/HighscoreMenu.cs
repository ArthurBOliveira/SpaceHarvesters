using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreMenu : MonoBehaviour
{
    public Text txtScores;

    private void Awake()
    {
        WWW scores = HighscoreAPI.GetScores();

        StartCoroutine(WaitForRequest(scores));
    }
        
    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            txtScores.text = "";

            List<HighScore> scores = HighscoreAPI.ConvertStringToHighscores(www.text);

            foreach(HighScore hs in scores)
            {
                txtScores.text += hs.Player + " : " + hs.Score + "\r\n";
            }
            
        }
        else
        {
            Debug.Log(www.error);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("First");
    }
}