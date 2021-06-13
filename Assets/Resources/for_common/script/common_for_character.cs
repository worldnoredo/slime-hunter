using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class common_for_character: common_for_object
{

    public GameObject show_damage_prefab;

    //character status
    public int max_health;
    protected int health;
    public int armor;
    public int damage;
    
    void Start()
    {
        health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void show_damage(int t_damage){
        GameObject text_show = Instantiate(show_damage_prefab,transform.position, Quaternion.identity) as GameObject;
        text_show.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text = t_damage.ToString();
    }
    public void take_damage(int t_damage){
        int true_damage = t_damage * 100 / (100 + armor);
        if (true_damage == 0) true_damage = 1;
        health -= true_damage;
        if (health < 0) health = 0;
        show_damage(true_damage);
    }
    public void restore_health(int percent){
        health = Mathf.Min(max_health,health + max_health * percent / 100);
    }
    public int get_cur_health(){
        return health;
    }
    public int get_cur_health_precent(){
        return (int)(health*100/max_health);
    }
    public void set_stat(int s_health,int s_armor,int s_damage){
        max_health = s_health;
        health = s_health;
        armor = s_armor;
        damage = s_damage;
    }
    
}

