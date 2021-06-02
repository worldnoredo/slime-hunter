using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int energy = 5;
    public int money = 1;
    protected GameObject player;
    protected bool is_move;
    protected bool is_attack;
    void Start()
    {
        player = GameObject.Find("Player");
        is_move = false;
        is_attack = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {   
        // check die
        if (gameObject.GetComponent<common_for_character>().get_cur_health() <= 0){
            be_die();
        }
        //check_move
        if (is_move){
            move();
        }
    }
    protected void be_die(){
        Destroy(gameObject);
        player.GetComponent<Player_controller>().take_energy(energy);
        player.GetComponent<Player_controller>().take_money(money);
    }
    protected virtual void move(){

    }
    protected void on_move(){
        is_move = true;
        rotate_to_player();
    }
    protected void off_move(){
        is_move = false;
    }
    protected void start_attack(){
        is_attack = true;
    }
    protected void end_atack(){
        is_attack = false;
    }
    protected float get_player_distance(){
        return Vector2.Distance(transform.position,player.transform.position);
    }
    protected void rotate_to_player(){
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right,player.transform.position-transform.position));
    }
}
