using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal_item : common_for_object
{
    public float time = 20f;
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void Update(){
        time -= Time.deltaTime;
        if (time <= 0){
            delete();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<common_for_character>().restore_health(10);
            delete();
        }
    }
}
