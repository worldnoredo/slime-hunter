using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range_enemy : enemy
{
    public int speed = 30;
    public int range = 30;
    public enemy_bullet bullet;

    protected override void move(){
        var rigid = GetComponent<Rigidbody2D>();
        if (get_player_distance() > range /2)
        rigid.velocity += new Vector2(transform.right.x,transform.right.y) * speed;
        
    }
    void spawn_bullet(){
        rotate_to_player();
        enemy_bullet bulletInstan = Instantiate(bullet,transform.position,transform.rotation) as enemy_bullet;
        int damage = gameObject.GetComponent<common_for_character>().damage;
        bulletInstan.set_damage(damage);
    }
    void check_in_range(){
        if (get_player_distance() < range){
            GetComponent<Animator>().SetTrigger("is_attack");
        }
    }
}
