using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
public class player_load_data : MonoBehaviour
{
    // Start is called before the first frame update
    private common_for_character common;
    private Player_controller controller;
    int damage;
    int health;
    float atk_speed;
    int armor;
    int money;
     /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        common = gameObject.GetComponent<common_for_character>();
        controller = gameObject.GetComponent<Player_controller>();
        LoadData();
    }
    public void LoadData(){
        if (File.Exists(Application.persistentDataPath 
                + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
                        File.Open(Application.persistentDataPath 
                        + "/MySaveData.dat", FileMode.Open);
            Data data = (Data)bf.Deserialize(file);
            file.Close();
            common.damage = data.damage;
            common.max_health = data.health;
            controller.atk_speed = data.atk_speed;
            common.armor = data.armor;
            controller.money = data.money;
            Debug.Log("Game data loaded!");
        }
        else {
            SaveData(10,1000,1,0,0);
            LoadData();
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
}
