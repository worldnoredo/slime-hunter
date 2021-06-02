using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
public class lose : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public GameObject money_number;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        
    }
    public void restartClick(){
        SaveData();
        SceneManager.LoadScene("playgame"); 
    }
    public void menuClick(){
        SaveData();
        SceneManager.LoadScene("mainmenu");
    }
    public void updateMoney(int money){
        money_number.GetComponent<TMPro.TextMeshProUGUI>().text = money.ToString();
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
    void SaveData(){
        int health = player.GetComponent<common_for_character>().max_health;
        int armor = player.GetComponent<common_for_character>().armor;
        float atk_speed = player.GetComponent<Player_controller>().atk_speed;
        int damage = player.GetComponent<common_for_character>().damage;
        int money = player.GetComponent<Player_controller>().money;
        SaveData(damage,health,atk_speed,armor,money);
    }
}