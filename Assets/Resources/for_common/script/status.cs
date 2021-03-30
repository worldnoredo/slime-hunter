using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status : MonoBehaviour
{
    // Start is called before the first frame update
    public int max_health;
    public int health;
    public int armor;
    public int damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void take_damage(int take){
        int true_damage = take * (100 - armor) / 100;
        if (true_damage == 0) true_damage = 1;
        health -= true_damage;
    }
}
