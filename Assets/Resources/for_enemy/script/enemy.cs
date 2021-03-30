using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : common_for_character
{
    // Start is called before the first frame update
    GameObject player;
    public int speed = 30;
    bool is_move;
    bool is_attack;
    void Start()
    {
        player = GameObject.Find("Player");
        is_move = false;
        is_attack = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health < 0){
            be_die();
        }
        
        if (is_move){
            move();
        }
    }
    void be_die(){
        Destroy(gameObject);
    }
    void move(){
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right,player.transform.position-transform.position));
        var rigid = GetComponent<Rigidbody2D>();
        rigid.velocity += new Vector2(transform.right.x,transform.right.y) * speed;
    }
    void on_move(){
        is_move = true;
    }
    void off_move(){
        is_move = false;
    }
    void start_attack(){
        is_attack = true;
    }
    void end_atack(){
        is_attack = false;
    }
    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Player"){
            if (is_attack){
                other.gameObject.GetComponent<player>().take_damage(damage);
            }
            is_attack = false;
        }
    }
}
