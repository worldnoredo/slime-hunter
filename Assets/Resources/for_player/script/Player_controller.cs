using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
public class Player_controller : MonoBehaviour
{
    
    public float speed = 50f;
    public float atk_speed = 1f;
    public float skill_reload_time = 20f;
    public float dodge_reload_time = 10f;
    public float change_weapon_reload_time = 3f;
    public int range_detected = 200;
    public int max_energy = 200;
    private int cur_energy; 
    public int skill_energy_cost = 100;
    public GameObject playerSprite;
    public Joystick move_joystick;
    public ClickButton fire_button;
    public ClickButton energy_button;
    public ClickButton dodge_button;
    public ClickButton change_weapon_button;
    public Bullet bullet;
    public Rocket rocket;
    public EnergySkill energy_skill;
    public GameObject shot_position;

    public int money;
    private float fire_reload_delay;
    private float skill_reload_delay;
    private float dodge_reload_delay;
    private float change_weapon_reload_delay;
    private GameObject target;
    private bool in_dodge;
    private bool in_rocket;
    private Vector2 direct;
    // Start is called before the first frame update
    void Start()
    {
        fire_reload_delay = 0;
        target = null;
        cur_energy = 0;
        skill_reload_delay = 0;
        direct = new Vector2(0,0);
        in_dodge = false;
        in_rocket = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fire_reload_delay > 0){
            fire_reload_delay -= Time.deltaTime;
        }
        if (skill_reload_delay > 0){
            skill_reload_delay -= Time.deltaTime;
        }
        if (dodge_reload_delay > 0){
            dodge_reload_delay -= Time.deltaTime;
        }
        if (change_weapon_reload_delay > 0){
            change_weapon_reload_delay -= Time.deltaTime;
        }

        
        //move and dodge
        if ( dodge_button.checkPressed() && dodge_reload_delay <= 0){       //click dodge button
            if (move_joystick.Horizontal != 0 || move_joystick.Vertical != 0){
                direct = move_joystick.Direction;
            } else direct = transform.right * -1;
            change_in_dodge();
            dodge_reload_delay = dodge_reload_time;
            target = null;      // reset target
        } else if (in_dodge){                                               // in dodge
            var rigid = GetComponent<Rigidbody2D>();
            rigid.velocity += direct * 3 * speed;
        }else {                                                             // normal move
            var rigid = GetComponent<Rigidbody2D>();
            rigid.velocity += new Vector2(move_joystick.Horizontal * speed, move_joystick.Vertical * speed);
        }

        if (!in_dodge){             // if in dodge, cannot interactive
            detect_enemy();
            //rotation by joystick
            if (move_joystick.Horizontal != 0 || move_joystick.Vertical != 0){
                gameObject.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right,move_joystick.Direction));
            }
            // or rotation to target if have target
            if (target!= null){
                gameObject.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right,target.transform.position-transform.position));
            }
            //fire
            if (fire_button.checkPressed() && fire_reload_delay <= 0){
                if (!in_rocket){
                    Bullet bulletInstan = Instantiate(bullet,shot_position.transform.position,transform.rotation) as Bullet;
                    int damage = gameObject.GetComponent<common_for_character>().damage;
                    bulletInstan.set_damage(damage);
                    fire_reload_delay = (1/atk_speed);
                } else {
                    Rocket rocketInstan = Instantiate(rocket,shot_position.transform.position,transform.rotation) as Rocket;
                    int damage = gameObject.GetComponent<common_for_character>().damage;
                    rocketInstan.set_damage(damage);
                    fire_reload_delay = (1.5f/atk_speed);
                }
            }
            //energy button
            if (energy_button.checkPressed() && skill_reload_delay <= 0 && cur_energy >= skill_energy_cost){
                EnergySkill energyInstance = Instantiate(energy_skill,transform.position,transform.rotation) as EnergySkill;
                int damage = gameObject.GetComponent<common_for_character>().damage;
                energyInstance.set_damage(damage);
                skill_reload_delay = skill_reload_time;
                cur_energy -= skill_energy_cost;
            }
            //change weapon button
            if (change_weapon_button.checkPressed() && change_weapon_reload_delay <= 0){
                bool cur = GetComponent<Animator>().GetBool("rocket");
                in_rocket = !cur;
                GetComponent<Animator>().SetBool("rocket",in_rocket);
                change_weapon_reload_delay = change_weapon_reload_time;
            }
        }

    }
    //find enemy
    void detect_enemy(){
        GameObject[] enemy_list = GameObject.FindGameObjectsWithTag("Enemy");
        if (target!= null && Vector2.Distance(transform.position,target.transform.position) > range_detected ){
            target = null;
        }
        if (enemy_list.Length != 0 && target == null) {
            foreach (var each in enemy_list){
                if (Vector2.Distance(transform.position,each.transform.position) < range_detected){
                    if (target == null){
                        target = each;
                    } else if (Vector2.Distance(transform.position,target.transform.position) - Vector2.Distance(transform.position,each.transform.position) > 0){
                        target = each;
                    }
                }
            }
        }
    }

    public int get_target_cur_health_percent(){
        if (target != null) {
            return target.GetComponent<common_for_character>().get_cur_health_precent();
        } else return 0;
    }
    public void take_energy(int energy){
        cur_energy  = Mathf.Min(cur_energy + energy, max_energy);
    }
    public void take_money(int t_money){
        money += t_money;
    }
    public int get_cur_energy_percent(){
        return (int)(cur_energy * 100 / max_energy);
    }

    public float get_skill_reload_delay(){
        return skill_reload_delay;
    }
    public bool is_enough_energy(){
        if (cur_energy >= skill_energy_cost) return true; else return false;
    }
    public float get_dodge_reload_delay(){
        return dodge_reload_delay;
    }

    void change_in_dodge(){
        GetComponent<Animator>().SetTrigger("in_dodge");
        in_dodge = true;

    }
    void change_out_dodge(){
        in_dodge = false;
    }
    public float get_change_weapon_reload_delay(){
        return change_weapon_reload_delay;
    }
}
