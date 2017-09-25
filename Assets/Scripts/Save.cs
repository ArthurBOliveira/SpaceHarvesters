using UnityEngine;
using System.Collections;

public class Save : MonoBehaviour
{

    public bool SaveScore(int recentScore)
    {
        int aux = HighScore();

        /*if (recentScore > aux)
        {*/
            PlayerPrefs.SetInt("RecentScore", recentScore);
        //}

        return recentScore > aux;
    }

    public void SaveCoins(int coins)
    {
        PlayerPrefs.SetInt("TotalCoins", coins);
    }

    public void SaveIdFacebook(string idFacebook)
    {
        PlayerPrefs.SetString("IdFacebook", idFacebook);
    }

    public int HighScore()
    {

        int highScore = PlayerPrefs.GetInt("RecentScore");

        return highScore;
    }

    public int TotalCoins()
    {

        int totalCoins = PlayerPrefs.GetInt("TotalCoins");

        return totalCoins;
    }

    public string IdFacebook()
    {
        string idFacebook = PlayerPrefs.GetString("IdFacebook");

        return idFacebook;
    }

    //Shield
    public int ShieldLevel()
    {

        int shieldLevel = PlayerPrefs.GetInt("ShieldLevel");

        return shieldLevel;
    }

    public void SaveShieldLevel(int shieldLevel)
    {
        PlayerPrefs.SetInt("ShieldLevel", shieldLevel);
    }

    public int ShieldCost()
    {
        int shieldCost = 0;

        switch (ShieldLevel())
        {
            case 0:
                shieldCost = 50;
                break;
            case 1:
                shieldCost = 200;
                break;

            case 2:
                shieldCost = 500;
                break;

            case 3:
                shieldCost = 1000;
                break;

            case 4:
                shieldCost = 2000;
                break;
        }

        return shieldCost;
    }

    //Weapons
    public int WeaponsLevel()
    {

        int weaponsLevel = PlayerPrefs.GetInt("WeaponsLevel");

        return weaponsLevel;
    }

    public void SaveWeaponsLevel(int weaponsLevel)
    {
        PlayerPrefs.SetInt("WeaponsLevel", weaponsLevel);
    }

    public int WeaponsCost()
    {
        int weaponsCost = 0;

        switch (WeaponsLevel())
        {
            case 0:
                weaponsCost = 50;
                break;
            case 1:
                weaponsCost = 200;
                break;

            case 2:
                weaponsCost = 500;
                break;

            case 3:
                weaponsCost = 1000;
                break;

            case 4:
                weaponsCost = 2000;
                break;
        }

        return weaponsCost;
    }

    //Bolt
    public int BoltLevel()
    {

        int boltLevel = PlayerPrefs.GetInt("BoltLevel");

        return boltLevel;
    }

    public void SaveBoltLevel(int boltLevel)
    {
        PlayerPrefs.SetInt("BoltLevel", boltLevel);
    }

    public int BoltCost()
    {
        int boltCost = 0;

        switch (BoltLevel())
        {
            case 0:
                boltCost = 50;
                break;
            case 1:
                boltCost = 200;
                break;

            case 2:
                boltCost = 500;
                break;

            case 3:
                boltCost = 1000;
                break;

            case 4:
                boltCost = 2000;
                break;
        }

        return boltCost;
    }
}