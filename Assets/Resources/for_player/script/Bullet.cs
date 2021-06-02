using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : common_for_object
{
    // Start is called before the first frame update
    public int speed = 10000;
    private int damage;
    void Start()
    {
        Rigidbody2D bulletRigid = GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(transform.right * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<common_for_character>().take_damage(damage);
        }
        delete();
    }
    public void set_damage(int s_damage){
        damage = s_damage;
    }
}
