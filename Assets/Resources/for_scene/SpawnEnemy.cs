using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnEnemy : MonoBehaviour
{
    public normal_enemy normal_enemy;
    public range_enemy range_enemy;
    public float time_respawn = 5f;
    private float time;
    private int count;
    void Start()
    {
        time = time_respawn;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0){
            time = time_respawn;
            spawn(normal_enemy,30+10*count,0+count/10,50+count*5,1+count);
            spawn(range_enemy,30+10*count,0+count/10,20+count*2,1+count);
            count++;
        }
    }
    void spawn(enemy obj, int health,int armor,int damage, int money){
        enemy ob = Instantiate(obj,new Vector3(Random.Range(-150,150),Random.Range(-150,150),0),Quaternion.identity) as enemy;
        ob.gameObject.GetComponent<common_for_character>().set_stat(health,armor,damage);
        ob.set_money(money);
    }
}
