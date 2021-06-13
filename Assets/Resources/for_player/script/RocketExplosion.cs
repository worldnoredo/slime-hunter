using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : common_for_object
{
    // Start is called before the first frame update

    private int damage;
    public GameObject sound;
    void Start()
    {
        Instantiate(sound,transform.position,transform.rotation);
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<common_for_character>().take_damage(damage);
        }
    }
    public void set_damage(int s_damage){
        damage = s_damage;
    }
}
