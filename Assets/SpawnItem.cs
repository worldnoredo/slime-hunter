using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public heal_item heal;
    public float time_respawn = 10f;
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
            Instantiate(heal,new Vector3(Random.Range(-150,150),Random.Range(-150,150),0),Quaternion.identity);  
        }
    }
}
