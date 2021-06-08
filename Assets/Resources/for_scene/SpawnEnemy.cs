using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public normal_enemy normal_enemy;
    public range_enemy range_enemy;
    public float time_respawn = 5f;
    private float time;
    void Start()
    {
        time = time_respawn;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0){
            time = time_respawn;
            Instantiate(normal_enemy,new Vector3(Random.Range(-150,150),Random.Range(-150,150),0),Quaternion.identity);
            Instantiate(range_enemy,new Vector3(Random.Range(-150,150),Random.Range(-150,150),0),Quaternion.identity);
        }
    }
}
