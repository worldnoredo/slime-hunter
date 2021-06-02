using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normal_enemy : enemy
{
    // Start is called before the first frame update
    public int speed = 30;

    // Update is called once per frame
    protected override void move(){
        var rigid = GetComponent<Rigidbody2D>();
        rigid.velocity += new Vector2(transform.right.x,transform.right.y) * speed;
    }
    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Player"){
            if (is_attack){
                other.gameObject.GetComponent<common_for_character>().take_damage(gameObject.GetComponent<common_for_character>().damage);
            }
            is_attack = false;
        }
    }
}
