using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using UnityEngine.SceneManagement;
public class UpdateScene : MonoBehaviour
{
    int damage;
    int health;
    float atk_speed;
    int armor;
    int money;
    public GameObject damageStat;
    public GameObject atkSpeedStat;
    public GameObject healthStat;
    public GameObject armorStat;
    public GameObject moneyStat;
    void Start()
    {
        LoadGame();
        updateStat();
    }
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        SaveData(damage,health,atk_speed,armor,money);
    }
    // Update is called once per frame
    void LoadGame(){
        if (File.Exists(Application.persistentDataPath 
                + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
                        File.Open(Application.persistentDataPath 
                        + "/MySaveData.dat", FileMode.Open);
            Data data = (Data)bf.Deserialize(file);
            file.Close();
            damage = data.damage;
            health = data.health;
            atk_speed = data.atk_speed;
            armor = data.armor;
            money = data.money;
            Debug.Log("Game data loaded!");
        }
        else {
            SaveData(10,1000,1,0,0);
            LoadGame();
        }
    }
    void SaveData(int s_damage,int s_health,float s_atk_speed,int s_armor,int s_money){
        BinaryFormatter bf = new BinaryFormatter(); 
	    FileStream file = File.Create(Application.persistentDataPath 
                 + "/MySaveData.dat");
        Data data = new Data() {
            damage = s_damage,
            health = s_health,
            atk_speed = s_atk_speed,
            armor = s_armor,
            money = s_money,
        };
        bf.Serialize(file, data);
        file.Close();
	    Debug.Log("Game data saved!");
    }
    void updateStat(){
        updateStatButton();
        damageStat.GetComponent<updateStat>().updateText(damage.ToString());
        armorStat.GetComponent<updateStat>().updateText(armor.ToString());
        healthStat.GetComponent<updateStat>().updateText(health.ToString());
        atkSpeedStat.GetComponent<updateStat>().updateText(atk_speed.ToString());
        moneyStat.GetComponent<updateStat>().updateText(money.ToString());
    }
    void updateStatButton(){
        updateDamageButton();
        updateAtkSpeedButton();
        updateArmorButton();
        updateHealthButton();
    }
    void updateDamageButton(){
        damageStat.GetComponent<updateStat>().updateButton(money >= damage);
    }
    void updateAtkSpeedButton(){
        atkSpeedStat.GetComponent<updateStat>().updateButton(money >= (atk_speed-1) * 100);
    }
    void updateArmorButton(){
        armorStat.GetComponent<updateStat>().updateButton(money >= armor);
    }
    void updateHealthButton(){
        healthStat.GetComponent<updateStat>().updateButton(money >= health/100);
    }
    public void clickMoneyButton(){
        money += 10;
        moneyStat.GetComponent<updateStat>().updateText(money.ToString());
        updateStatButton();
    }
    public void clickDamageButton(){
        money -= damage;
        damage += 10;
        damageStat.GetComponent<updateStat>().updateText(damage.ToString());
        moneyStat.GetComponent<updateStat>().updateText(money.ToString());
        updateStatButton();
    }
    public void clickArmorButton(){
        money -= armor;
        armor += 10;
        armorStat.GetComponent<updateStat>().updateText(armor.ToString());
        moneyStat.GetComponent<updateStat>().updateText(money.ToString());
        updateStatButton();
    }
    public void clickHealthButton(){
        money -= health / 100;
        health += 100;
        healthStat.GetComponent<updateStat>().updateText(health.ToString());
        moneyStat.GetComponent<updateStat>().updateText(money.ToString());
        updateStatButton();
    }
    public void clickAtkSpeedButton(){
        money -= (int)((atk_speed-1) * 100);
        atk_speed += 0.1f;
        atkSpeedStat.GetComponent<updateStat>().updateText(atk_speed.ToString());
        moneyStat.GetComponent<updateStat>().updateText(money.ToString());
        updateStatButton();
    }
    public void resetData(){
        health = 1000;
        damage = 10;
        armor = 0;
        atk_speed = 1;
        money = 0;
        SaveData(damage,health,atk_speed,armor,money);
        updateStat();
    }
    public void return_title(){
        SceneManager.LoadScene(0);
    }
}


