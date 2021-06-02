using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : common_for_object
{
    // Start is called before the first frame update
    public int speed = 1000;
    private int damage;
    void Start()
    {
        Rigidbody2D bulletRigid = GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(transform.right * speed);
    }

    
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name == "Player"){
            other.gameObject.GetComponent<common_for_character>().take_damage(damage);
        }
        Destroy(gameObject);
    }
    public void set_damage(int s_damage){
        damage = s_damage;
    }
}
