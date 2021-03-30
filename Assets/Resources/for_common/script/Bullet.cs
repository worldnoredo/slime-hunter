using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : common_for_object
{
    // Start is called before the first frame update
    private int damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<enemy>().take_damage(damage);
        }
        Destroy(gameObject);
        
    }
    public void set_damage(int s_damage){
        damage = s_damage;
    }
}
