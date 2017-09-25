using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighscoreAPI
{
    private const string URL = "https://highscore-counter.herokuapp.com/";
    private const string GAME = "SpaceHarvesters";

    public static WWW SaveScore(HighScore score)
    {
        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");
        headers.Add("Access-Control-Allow-Origin", "http://uploads.ungrounded.net");

        byte[] pData = System.Text.Encoding.ASCII.GetBytes(score.ConvertToString(GAME).ToCharArray());

        return new WWW(URL + "highscore", pData, headers);
    }

    public static WWW GetScores()
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");
        headers.Add("Access-Control-Allow-Origin", "http://uploads.ungrounded.net");

        return new WWW(URL + "highscore/listbygame/" + GAME, null, headers);
    }

    public static List<HighScore> ConvertStringToHighscores(string text)
    {
        List<HighScore> result = new List<HighScore>();

        string[] scores = text.Split('{');

        for(int i = 1; i < scores.Length; i++)
        {
            result.Add(new HighScore(scores[i]));
        }

        return result;
    }
}

public class HighScore
{
    public string Player { get; set; }
    public int Score { get; set; }

    public HighScore() { }
    public HighScore(string text)
    {
        try
        {
            string[] props = text.Split(':');
            Debug.Log(props);

            Player = props[2].Split('"')[1];
            Score = int.Parse(props[3].Split(',')[0]);
        }
        catch (Exception ex)
        {
            Player = "Errou!";
            Score = 0;
        }
    }

    public string ConvertToString(string game)
    {
        string result = "{";

        result += "\"player\":" + "\"" + Player +"\",";
        result += "\"score\":" + "\"" + Score + "\",";
        result += "\"game\":" + "\"" + game + "\"";

        result += "}";

        Debug.Log(result);

        return result;
    }
}