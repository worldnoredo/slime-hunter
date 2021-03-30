using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed = 50f;
    public float reload_time = 0.5f;
    public int range_detected = 500;

    public GameObject playerSprite;
    public Joystick move_joystick;
    public FireButton fire_button;
    public Bullet bullet;
    public GameObject shot_position;
    public GameObject enemy_health_render;
    
    Vector2 move_rotate;
    Vector2 atk_rotate;
    private float reload_delay;

    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        reload_delay = 0;
        move_rotate = new Vector2(0,0);
        atk_rotate = new Vector2(0,0);
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (reload_delay > 0){
            reload_delay -= Time.deltaTime;
        }
        detect_enemy();

        var rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(move_joystick.Horizontal * speed,
                                    move_joystick.Vertical * speed);
        //rotation by joystick
        if (move_joystick.Horizontal != 0 && move_joystick.Vertical != 0){
            // Quaternion newQua = Quaternion.identity;
            // newQua.eulerAngles = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,move_joystick.Direction));
            // gameObject.transform.rotation = newQua;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right,move_joystick.Direction));
        }  
        //rotation to target
        if (target!= null){
            gameObject.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right,target.transform.position-transform.position));
        }
        //fire
        if (fire_button.checkPressed() && reload_delay <= 0){
            Bullet bulletInstan = Instantiate(bullet,shot_position.transform.position,transform.rotation) as Bullet;
            Rigidbody2D bulletRigid = bulletInstan.GetComponent<Rigidbody2D>();
            bulletRigid.AddForce(transform.right * 30000);

            int damage = gameObject.GetComponent<player>().damage;
            bulletInstan.set_damage(damage);
            reload_delay = reload_time;
        }

    }
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

}
