using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{

    public GUIText coinsText;

    public GUIText alertText;

    public GUIText shieldLevelText;
    public GUIText shieldCostText;

    public GUIText weaponsLevelText;
    public GUIText weaponsCostText;

    public GUIText boltLevelText;
    public GUIText boltCostText;

    public Button btnUpgShield;
    public Button btnUpgWeapon;
    public Button btnUpgBolt;

    private Save save;
    private int coins;

    private int shieldLevel;
    private int shieldCost;

    private int weaponsLevel;
    private int weaponsCost;

    private int boltLevel;
    private int boltCost;

    void Start()
    {
        save = new Save();

        coins = save.TotalCoins();
        coinsText.text = "Coins: " + coins;

        //Shield
        shieldLevel = save.ShieldLevel();
        shieldCost = save.ShieldCost();

        shieldLevelText.text = "Shield " + shieldLevel;
        shieldCostText.text = "Cost: " + shieldCost;

        //Weapons
        weaponsLevel = save.WeaponsLevel();
        weaponsCost = save.WeaponsCost();

        weaponsLevelText.text = "Weapons " + weaponsLevel;
        weaponsCostText.text = "Cost: " + weaponsCost;

        //Bolt
        boltLevel = save.BoltLevel();
        boltCost = save.BoltCost();

        boltLevelText.text = "Bolt " + boltLevel;
        boltCostText.text = "Cost: " + boltCost;

        Debug.Log(shieldLevel);

        if (shieldLevel > 4)
            btnUpgShield.gameObject.SetActive(false);
        if (weaponsLevel > 4)
            btnUpgWeapon.gameObject.SetActive(false);
        if (boltLevel > 4)
            btnUpgBolt.gameObject.SetActive(false);

        alertText.text = "";
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("First");
    }

    public void UpgradeShield()
    {

        if (coins >= shieldCost)
        {
            if (shieldLevel < 4)
            {
                int level = save.ShieldLevel() + 1;

                save.SaveShieldLevel(level);

                alertText.text = "upgrade successful";
                alertText.color = new Color(255, 139, 255);

                coins -= shieldCost;

                save.SaveCoins(coins);

                shieldCost = save.ShieldCost();

                coinsText.text = "Coins: " + coins;
                shieldLevelText.text = "Shield " + level;
                shieldCostText.text = "Cost: " + shieldCost;
            }
            else
            {
                alertText.text = "Max Upgraded";
                alertText.color = new Color(255, 0, 0);
                btnUpgShield.gameObject.SetActive(false);
            }
        }
        else
        {
            alertText.text = "insufficient coins";
            alertText.color = new Color(255, 0, 0);
        }
    }

    public void UpgradeWeapons()
    {

        if (coins >= weaponsCost)
        {
            if (weaponsLevel < 4)
            {
                int level = save.WeaponsLevel() + 1;

                save.SaveWeaponsLevel(level);

                alertText.text = "upgrade successful";
                alertText.color = new Color(255, 139, 255);

                coins -= weaponsCost;

                save.SaveCoins(coins);

                weaponsCost = save.WeaponsCost();

                coinsText.text = "Coins: " + coins;
                weaponsLevelText.text = "Bolt " + level;
                weaponsCostText.text = "Cost: " + weaponsCost;
            }
            else
            {
                alertText.text = "Max Upgraded";
                alertText.color = new Color(255, 0, 0);
                btnUpgWeapon.gameObject.SetActive(false);
            }
        }
        else
        {
            alertText.text = "insufficient coins";
            alertText.color = new Color(255, 0, 0);
        }
    }

    public void UpgradeBolt()
    {

        if (coins >= boltCost)
        {
            if (boltLevel < 4)
            {
                int level = save.BoltLevel() + 1;

                save.SaveBoltLevel(level);

                alertText.text = "upgrade successful";
                alertText.color = new Color(255, 139, 255);

                coins -= boltCost;

                save.SaveCoins(coins);

                boltCost = save.BoltCost();

                coinsText.text = "Coins: " + coins;
                boltLevelText.text = "Weapons " + level;
                boltCostText.text = "Cost: " + boltCost;
            }
            else
            {
                alertText.text = "Max Upgraded";
                alertText.color = new Color(255, 0, 0);
                btnUpgBolt.gameObject.SetActive(false);
            }
        }
        else
        {
            alertText.text = "insufficient coins";
            alertText.color = new Color(255, 0, 0);
        }
    }
}
