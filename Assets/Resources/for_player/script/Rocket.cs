using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : common_for_object
{
    // Start is called before the first frame update
    public int speed = 10000;
    public RocketExplosion rocket_explosion;
    private int damage;
    void Start()
    {
        Rigidbody2D bulletRigid = GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(transform.right * speed);
    }
    void Update()
    {
        
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<common_for_character>().take_damage(damage);
            RocketExplosion new_explosion = Instantiate(rocket_explosion,transform.position,transform.rotation) as RocketExplosion;
            new_explosion.set_damage(damage / 3);
        }
        delete();
    }
    public void set_damage(int s_damage){
        damage = s_damage;
    }
}
