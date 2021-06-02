using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySkill : common_for_object
{
    private int damage;
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<common_for_character>().take_damage(damage*3);
        }
        if (other.gameObject.tag == "EnemyBullet"){
            other.gameObject.GetComponent<common_for_object>().delete();
        }
    }
    public void set_damage(int s_damage){
        damage = s_damage;
    }
}