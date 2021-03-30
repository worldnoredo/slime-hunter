using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public float time_respawn = 5f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time_respawn -= Time.deltaTime;
        if (time_respawn <= 0){
            time_respawn = 5;
            Instantiate(enemy,new Vector3(Random.Range(-150,150),Random.Range(-150,150),0),Quaternion.identity);
        }
    }
}
